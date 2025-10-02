using Client.UserControls;
using Common.Communication;
using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Client.GuiController
{
    public class ReversGuiController
    {
        private UCDodajRevers dodajRevers;
        private UCDodajStavke dodajStavke;
        private Form forma;
        private Revers revers;

        // =======================
        // KREIRANJE NOVOG REVERSA
        // =======================

        internal Control CreateDodajRevers()
        {
            dodajRevers = new UCDodajRevers();

            // 1) Kontroler preuzima učitavanje (binduje podatke u view)
            dodajRevers.ViewLoaded += OnViewLoaded;

            // 2) Flow kreiranja reversa
            dodajRevers.btnDodaj.Click += AddRevers;

            return dodajRevers;
        }

        private void OnViewLoaded(object sender, EventArgs e)
        {
            try
            {
                var lista = (List<Klijent>)Communication.Instance.GetAllKlijent();
                var binding = new BindingList<Klijent>(lista ?? new List<Klijent>());

                // “Ubrizgaj” podatke u view
                dodajRevers.BindKlijenti(binding);
                dodajRevers.SetDatum(DateTime.Today);
                dodajRevers.SetZaposleni(LoginGuiController.Instance.Z);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju klijenata: " + ex.Message);
            }
        }

        private void AddRevers(object sender, EventArgs e)
        {
            var izabrani = dodajRevers.cmbKlijent.SelectedItem as Klijent;
            if (izabrani == null)
            {
                MessageBox.Show("Morate izabrati klijenta!");
                return;
            }

            try
            {
                revers = new Revers
                {
                    Datum = dodajRevers.danas,
                    Zaposleni = LoginGuiController.Instance.Z,
                    Klijent = izabrani,
                    Stavke = null
                };

                var response = Communication.Instance.CreateRevers(revers);

                // neuspeh: null response, poruka o grešci ili nema rezultata
                if (response == null ||
                    !string.IsNullOrEmpty(response.ExceptionMessage) ||
                    response.Result is not Revers r)
                {
                    MessageBox.Show("Sistem ne može da kreira revers");
                    return;
                }

                // uspeh
                revers = r;
                MessageBox.Show("Sistem je kreirao revers");
                OpenStavkeFormForRevers(revers);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("CreateRevers greška: " + ex.Message);
                MessageBox.Show("Sistem ne može da kreira revers");
            }
        }


        // Otvaranje FrmStavke za dati revers (koristi se i kod kreiranja i kod detalja)
        private void OpenStavkeFormForRevers(Revers rHeader)
        {
            var frmStavke = new FrmStavke();
            forma = frmStavke;
            dodajStavke = frmStavke.uc;

            frmStavke.tbDatum.Text = rHeader.Datum.ToString("dd.MM.yyyy.");
            frmStavke.tbKlijent.Text = Convert.ToString(rHeader.Klijent);
            frmStavke.tbZaposleni.Text = Convert.ToString(rHeader.Zaposleni);
            // broj reversa
            dodajStavke.SetBrojReversa(rHeader.Id);

            // robe (za ComboBox i hidraciju prikaza)
            var robe = Communication.Instance.GetRoba(null) ?? new List<Roba>();
            var robeBL = new BindingList<Roba>(robe);
            dodajStavke.BindRobe(robeBL);

            // (Re)inicijalizuj BindingList ako treba
            if (dodajStavke.Stavke == null)
                dodajStavke.Stavke = new BindingList<StavkaReversa>();

            // Ako otvaramo postojeći revers (detalji/izmena), učitaj stavke
            var postojeceStavke = LoadStavkeForReversSafe(rHeader.Id);
            if (postojeceStavke != null && postojeceStavke.Count > 0)
            {
                // hidrira robu po Id da bi RobaPrikaz imao naziv
                var mapaRobe = robe.ToDictionary(x => x.Id, x => x);
                foreach (var s in postojeceStavke)
                {
                    if (s.Roba != null && mapaRobe.TryGetValue(s.Roba.Id, out var rob))
                        s.Roba = rob;
                }
                dodajStavke.Stavke = new BindingList<StavkaReversa>(postojeceStavke);
                dodajStavke.dgvStavke.DataSource = null;
                dodajStavke.dgvStavke.DataSource = dodajStavke.Stavke;
            }

            // handleri (skloni stare pa dodaj nove da ne dupliramo)
            dodajStavke.btnDodaj.Click -= AddStavke;
            dodajStavke.btnSacuvaj.Click -= SacuvajStavke;
            dodajStavke.btnObrisi.Click -= DeleteStavka;
            dodajStavke.btnAzuriraj.Click -= AzurirajStavka;

            dodajStavke.btnDodaj.Click += AddStavke;
            dodajStavke.btnSacuvaj.Click += SacuvajStavke;
            dodajStavke.btnObrisi.Click += DeleteStavka;
            dodajStavke.btnAzuriraj.Click += AzurirajStavka;

            // rollback ako korisnik zatvori formu bez stavki (samo za svež header, harmless i kod detalja)
            frmStavke.FormClosing -= FrmStavke_FormClosing;
            frmStavke.FormClosing += FrmStavke_FormClosing;

            revers = rHeader; // trenutno aktivni header

            frmStavke.ShowDialog();
        }

        private void FrmStavke_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (revers != null && (dodajStavke?.Stavke == null || dodajStavke.Stavke.Count == 0))
                {
                    // rollback praznog header-a (bez poruke)
                    Communication.Instance.DeleteRevers(revers);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Rollback greška pri zatvaranju: " + ex.Message);
            }
        }

        private void AddStavke(object sender, EventArgs e)
        {
            if (!TryReadStavkaInput(out var roba, out var kolicina)) return;

            var stavka = new StavkaReversa
            {
                Roba = roba,
                Kolicina = kolicina,
                IznosStavke = Math.Round(kolicina * (roba?.Cena ?? 0m), 2)
            };

            dodajStavke.Stavke.Add(stavka);
            RefreshGrid();

            dodajStavke.tbKolicina.Clear();
            dodajStavke.cmbRoba.Focus();
        }

        private void DeleteStavka(object sender, EventArgs e)
        {
            if (dodajStavke.Stavke == null || dodajStavke.Stavke.Count == 0)
            {
                MessageBox.Show("Nema stavki za brisanje.");
                return;
            }

            var (idx, sel) = TryGetSelectedStavka();
            if (idx < 0 || sel == null)
            {
                MessageBox.Show("Izaberite stavku u tabeli koju želite da obrišete.");
                return;
            }

            var dr = MessageBox.Show("Obrisati izabranu stavku?", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes) return;

            dodajStavke.Stavke.RemoveAt(idx);
            RefreshGrid();
        }

        private void AzurirajStavka(object sender, EventArgs e)
        {
            if (dodajStavke.Stavke == null || dodajStavke.Stavke.Count == 0)
            {
                MessageBox.Show("Nema stavki za ažuriranje.");
                return;
            }

            var (idx, sel) = TryGetSelectedStavka();
            if (idx < 0 || sel == null)
            {
                MessageBox.Show("Izaberite stavku u tabeli koju želite da ažurirate.");
                return;
            }

            Roba novaRoba = sel.Roba;
            if (dodajStavke.cmbRoba.SelectedItem is Roba r)
                novaRoba = r;

            decimal novaKolicina = sel.Kolicina;
            var txtK = (dodajStavke.tbKolicina.Text ?? "").Trim();
            if (!string.IsNullOrEmpty(txtK))
            {
                if (!TryParseDecimal(txtK, out var k) || k <= 0)
                {
                    MessageBox.Show("Unesite ispravnu količinu (> 0).");
                    return;
                }
                novaKolicina = k;
            }

            if (novaRoba == null || novaRoba.Id <= 0)
            {
                MessageBox.Show("Morate izabrati robu.");
                return;
            }

            sel.Roba = novaRoba;
            sel.Kolicina = novaKolicina;
            sel.IznosStavke = Math.Round(novaKolicina * (novaRoba?.Cena ?? 0m), 2);

            RefreshGrid();
            dodajStavke.cmbRoba.Focus();
        }

        private void SacuvajStavke(object sender, EventArgs e)
        {
            if (!ValidateBeforeSave()) return;

            // Rb dodeljuje server (UpdateReversSO)
            revers.Stavke = dodajStavke.Stavke.ToList();

            try
            {
                var response = Communication.Instance.UpdateRevers(revers);

                if (response != null && string.IsNullOrEmpty(response.ExceptionMessage))
                {
                    MessageBox.Show("Sistem je zapamtio revers");
                    // osveži grid u FrmRevers i zadrži selekciju na izmenjenom reversu
                    RefreshReversGridAfterEdit(revers?.Id ?? 0);

                    forma?.Close();
                    forma?.Dispose();
                }
                else
                {
                    // neuspeh bez bacenog exception-a (server vratio gresku u response-u)
                    MessageBox.Show("Sistem ne može da zapamti revers");
                }
            }
            catch (Exception ex)
            {
                // neuspeh uz exception (mreza/komunikacija i sl.)
                System.Diagnostics.Debug.WriteLine("Greška pri čuvanju reversa: " + ex.Message);
                MessageBox.Show("Sistem ne može da zapamti revers");
            }
        }


        // =======================
        // PRETRAGA / LISTING (FrmRevers)
        // =======================

        private FrmRevers frmRevers;
        private List<Revers> _sviReversi;
        private List<Klijent> _sviKlijenti;
        private List<Zaposleni> _sviZaposleni;

        // Otvori listu reversa
        public void ShowFrmPretragaReversa(Form parent)
        {
            frmRevers = new FrmRevers();
            frmRevers.Load += FrmRevers_Load;
            frmRevers.btnPretrazi.Click += BtnPretrazi_Click;
            frmRevers.btnDetalji.Click += BtnDetalji_Click;

            frmRevers.ShowDialog(parent);
        }

        private void FrmRevers_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigureReversGrid();

                // referentne liste (za hidrataciju prikaza)
                _sviKlijenti = (List<Klijent>)Communication.Instance.GetAllKlijent() ?? new List<Klijent>();
                _sviZaposleni = TryGetAllZaposleniSafe() ?? new List<Zaposleni>();

                // ucitaj sve revers(e)
                _sviReversi = Communication.Instance.GetAllRevers() ?? new List<Revers>();

                // hidracija imena/prezimena u Revers (da rade KlijentPrikaz/ZaposleniPrikaz)
                var klMap = _sviKlijenti.ToDictionary(k => k.Id, k => k);
                var zpMap = _sviZaposleni.ToDictionary(z => z.Id, z => z);

                foreach (var r in _sviReversi)
                {
                    if (r?.Klijent?.Id > 0 && klMap.TryGetValue(r.Klijent.Id, out var k))
                        r.Klijent = k;

                    if (r?.Zaposleni?.Id > 0 && zpMap.TryGetValue(r.Zaposleni.Id, out var z))
                        r.Zaposleni = z;
                }

                frmRevers.dgvReversi.DataSource = new BindingList<Revers>(_sviReversi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju podataka: " + ex.Message);
            }
        }

        private void ConfigureReversGrid()
        {
            var dgv = frmRevers.dgvReversi;
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                HeaderText = "Id Reversa",
                DataPropertyName = nameof(Revers.Id),
                Width = 80,
                ReadOnly = true,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDatum",
                HeaderText = "Datum",
                DataPropertyName = nameof(Revers.Datum),
                Width = 120,
                ReadOnly = true,
                DefaultCellStyle = { Format = "dd.MM.yyyy" }
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colZaposleni",
                HeaderText = "Zaposleni",
                DataPropertyName = nameof(Revers.ZaposleniPrikaz),
                Width = 200,
                ReadOnly = true
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colKlijent",
                HeaderText = "Klijent",
                DataPropertyName = nameof(Revers.KlijentPrikaz),
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colUkupno",
                HeaderText = "Ukupna cena",
                DataPropertyName = nameof(Revers.UkupnaCena),
                Width = 130,
                ReadOnly = true,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N2" }
            });

            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;
        }

        // server-side search
        // server-side search
        private void BtnPretrazi_Click(object sender, EventArgs e)
        {
            var filter = (frmRevers.tbFilter.Text ?? "").Trim();
            List<Revers> rezultat;

            try
            {
                // prazno -> uzmi sve; inače traži po filtru na serveru
                rezultat = string.IsNullOrWhiteSpace(filter)
                    ? (Communication.Instance.GetAllRevers() ?? new List<Revers>())
                    : (Communication.Instance.GetRevers(filter) ?? new List<Revers>());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom pretrage: " + ex.Message);
                return;
            }

            // hidracija prikaza (da rade KlijentPrikaz / ZaposleniPrikaz)
            HydrateNames(rezultat);

            frmRevers.dgvReversi.DataSource = new BindingList<Revers>(rezultat);

            // ⇩ poruke po uslovu
            if (rezultat != null && rezultat.Count > 0)
                MessageBox.Show("Sistem je našao reverse po zadatim kriterijumima");
            else
                MessageBox.Show("Sistem ne može da nađe reverse po zadatim kriterijumima");
        }


        // mala pomoćna da dopuni imena/prezimena u Revers objektima
        private void HydrateNames(IEnumerable<Revers> list)
        {
            // obezbedi referentne liste ako nedostaju
            _sviKlijenti ??= Communication.Instance.GetAllKlijent() ?? new List<Klijent>();
            _sviZaposleni ??= TryGetAllZaposleniSafe() ?? new List<Zaposleni>();

            var klMap = _sviKlijenti.ToDictionary(k => k.Id, k => k);
            var zpMap = _sviZaposleni.ToDictionary(z => z.Id, z => z);

            foreach (var r in list ?? Enumerable.Empty<Revers>())
            {
                if (r?.Klijent?.Id > 0 && klMap.TryGetValue(r.Klijent.Id, out var k)) r.Klijent = k;
                if (r?.Zaposleni?.Id > 0 && zpMap.TryGetValue(r.Zaposleni.Id, out var z)) r.Zaposleni = z;
            }
        }

        // Klik na Detalji – otvori FrmStavke za selektovani revers
        // Klik na Detalji – otvori FrmStavke za selektovani revers
        private void BtnDetalji_Click(object sender, EventArgs e)
        {
            var r = frmRevers.dgvReversi.CurrentRow?.DataBoundItem as Revers;
            if (r == null)
            {
                MessageBox.Show("Izaberite revers iz liste.");
                return;
            }

            try
            {
                // uspešan slučaj
                MessageBox.Show("Sistem je našao revers");
                OpenStavkeFormForRevers(r);
            }
            catch (Exception)
            {
                // neuspešan slučaj (npr. problem u komunikaciji / učitavanju stavki)
                MessageBox.Show("Sistem ne može da nađe revers");
            }
        }


        // =======================
        // Pomocne / Validacione
        // =======================

        private List<StavkaReversa> LoadStavkeForReversSafe(long idRevers)
        {
            try
            {
                return Communication.Instance.GetStavkeByRevers(idRevers) ?? new List<StavkaReversa>();
            }
            catch
            {
                return new List<StavkaReversa>();
            }
        }

        private List<Zaposleni> TryGetAllZaposleniSafe()
        {
            try
            {
                return Communication.Instance.GetAllZaposleni();
            }
            catch { return null; }
        }

        private bool TryReadStavkaInput(out Roba roba, out decimal kolicina)
        {
            roba = null;
            kolicina = 0m;

            if (!(dodajStavke.cmbRoba.SelectedItem is Roba selRoba) || selRoba.Id <= 0)
            {
                MessageBox.Show("Morate izabrati robu.");
                return false;
            }

            var txt = (dodajStavke.tbKolicina.Text ?? "").Trim();
            if (!TryParseDecimal(txt, out var k) || k <= 0)
            {
                MessageBox.Show("Unesite ispravnu količinu (> 0).");
                return false;
            }

            roba = selRoba;
            kolicina = k;
            return true;
        }

        private bool TryParseDecimal(string s, out decimal value)
        {
            if (decimal.TryParse(s, NumberStyles.Number, CultureInfo.CurrentCulture, out value))
                return true;
            if (decimal.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out value))
                return true;
            return false;
        }

        private (int idx, StavkaReversa stavka) TryGetSelectedStavka()
        {
            var row = dodajStavke.dgvStavke?.CurrentRow;
            if (row == null) return (-1, null);
            var data = row.DataBoundItem as StavkaReversa;
            if (data == null) return (-1, null);
            return (row.Index, data);
        }

        private void RefreshGrid()
        {
            var src = dodajStavke.Stavke;
            dodajStavke.dgvStavke.DataSource = null;
            dodajStavke.dgvStavke.DataSource = src;
        }

        private bool ValidateBeforeSave()
        {
            if (revers == null || revers.Id <= 0)
            {
                MessageBox.Show("Revers nije validno kreiran (nema ID).");
                return false;
            }

            if (dodajStavke.Stavke == null || dodajStavke.Stavke.Count == 0)
            {
                MessageBox.Show("Revers mora sadržati barem jednu stavku!");
                try { Communication.Instance.DeleteRevers(revers); }
                catch (Exception ex) { MessageBox.Show("Rollback greška: " + ex.Message); }
                return false;
            }

            foreach (var s in dodajStavke.Stavke)
            {
                if (s.Roba == null || s.Roba.Id <= 0)
                {
                    MessageBox.Show("Sve stavke moraju imati izabranu robu.");
                    return false;
                }
                if (s.Kolicina <= 0)
                {
                    MessageBox.Show("Sve stavke moraju imati količinu veću od 0.");
                    return false;
                }
            }

            return true;
        }

        //helper koji osvežava grid u FrmRevers i vraća selekciju na konkretan ID
        private void RefreshReversGridAfterEdit(long editedReversId)
        {
            try
            {
                if (frmRevers == null || frmRevers.IsDisposed) return;

                var filter = (frmRevers.tbFilter.Text ?? "").Trim();
                List<Revers> rezultat = string.IsNullOrWhiteSpace(filter)
                    ? (Communication.Instance.GetAllRevers() ?? new List<Revers>())
                    : (Communication.Instance.GetRevers(filter) ?? new List<Revers>());

                HydrateNames(rezultat);

                var bl = new BindingList<Revers>(rezultat);
                frmRevers.dgvReversi.DataSource = bl;

                // vrati selekciju na izmenjeni red
                if (editedReversId > 0)
                {
                    foreach (DataGridViewRow row in frmRevers.dgvReversi.Rows)
                    {
                        if (row?.DataBoundItem is Revers rr && rr.Id == editedReversId)
                        {
                            row.Selected = true;
                            if (row.Cells.Count > 0)
                                frmRevers.dgvReversi.CurrentCell = row.Cells[0];
                            break;
                        }
                    }
                }
            }
            catch
            {
                // tiho ignoriši – UI ostaje stabilan čak i ako refresh ne uspe
            }
        }
    }
}
