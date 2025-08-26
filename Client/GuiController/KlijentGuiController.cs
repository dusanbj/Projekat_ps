using Client.UserControls;
using Common.Communication;
using Domen;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Client.GuiController
{
    public class KlijentGuiController
    {
        // UC za dodavanje
        private UCDodajKlijenta view;

        // Forma/lista klijenata
        private FrmKlijenti listView;
        private BindingList<Klijent> _klijenti;

        /// <summary>
        /// Kreira i konfiguriše UC za dodavanje klijenta (vezuje evente).
        /// </summary>
        internal Control CreateDodajKlijenta()
        {
            view = new UCDodajKlijenta();

            // format prikaza mesta
            view.cbMesto.Format += (s, e) =>
            {
                if (e.ListItem is Mesto m) e.Value = $"{m.Naziv} ({m.Ptt})";
            };

            // Dugmad
            view.btnSacuvaj.Click += AddKlijent;
            view.btnDodajGrad.Click += BtnDodajGrad_Click;

            // Enter u TB -> submit
            view.tbIme.KeyDown += SubmitOnEnter;
            view.tbPrezime.KeyDown += SubmitOnEnter;
            view.tbBrojTelefona.KeyDown += SubmitOnEnter;
            view.cbMesto.KeyDown += SubmitOnEnter;

            return view;
        }

        private void SubmitOnEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddKlijent(sender, EventArgs.Empty);
                e.Handled = true;
            }
        }

        /// <summary>
        /// Otvori rad sa Mestima i osveži combobox po zatvaranju (za UC).
        /// </summary>
        private void BtnDodajGrad_Click(object sender, EventArgs e)
        {
            try
            {
                MainCoordinator.Instance.ShowRadSaMestima();
                RefreshMesta();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri otvaranju rada sa mestima: " + ex.Message);
            }
        }

        private void RefreshMesta()
        {
            try
            {
                var lista = Communication.Instance.GetAllMesto() ?? new System.Collections.Generic.List<Mesto>();
                var ds = new BindingList<Mesto>(lista);
                view.cbMesto.DataSource = ds;
                view.cbMesto.DisplayMember = nameof(Mesto.Naziv);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri osvežavanju mesta: " + ex.Message);
            }
        }

        /// <summary>
        /// Validacija + poziv CreateKlijent na serveru (UC).
        /// </summary>
        private void AddKlijent(object sender, EventArgs e)
        {
            try
            {
                var ime = (view.tbIme.Text ?? "").Trim();
                var prezime = (view.tbPrezime.Text ?? "").Trim();
                var tel = (view.tbBrojTelefona.Text ?? "").Trim();
                var mesto = view.cbMesto.SelectedItem as Mesto;

                if (string.IsNullOrWhiteSpace(ime))
                {
                    MessageBox.Show("Unesite ime."); view.tbIme.Focus(); return;
                }
                if (string.IsNullOrWhiteSpace(prezime))
                {
                    MessageBox.Show("Unesite prezime."); view.tbPrezime.Focus(); return;
                }
                if (string.IsNullOrWhiteSpace(tel))
                {
                    MessageBox.Show("Unesite broj telefona."); view.tbBrojTelefona.Focus(); return;
                }
                if (mesto == null)
                {
                    MessageBox.Show("Izaberite mesto."); view.cbMesto.DroppedDown = true; return;
                }

                var klijent = new Klijent
                {
                    Ime = ime,
                    Prezime = prezime,
                    BrTelefona = tel,
                    Mesto = new Mesto { Ptt = mesto.Ptt } // bitno: setuj Ptt!
                };

                Communication.Instance.CreateKlijent(klijent); // server radi duplikat check
                MessageBox.Show("Klijent uspešno dodat.");
                ResetUcForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri dodavanju klijenta: " + ex.Message);
            }
        }

        private void ResetUcForm()
        {
            view.tbIme.Clear();
            view.tbPrezime.Clear();
            view.tbBrojTelefona.Clear();
            if (view.cbMesto.Items.Count > 0) view.cbMesto.SelectedIndex = 0;
            view.tbIme.Focus();
        }

        // =================== LISTA/FORMA KLIJENATA ===================

        public Form CreateFrmKlijenti()
        {
            listView = new FrmKlijenti();

            listView.Load += FrmKlijenti_Load;
            listView.dgvKlijenti.SelectionChanged += DgvKlijenti_SelectionChanged;

            listView.btnSacuvaj.Click += BtnDodaj_Click_List;
            listView.btnAzuriraj.Click += BtnAzuriraj_Click_List;
            listView.btnObrisi.Click += BtnObrisi_Click_List;

            return listView;
        }

        internal void ShowFrmKlijenti(Form parent)
        {
            using var frm = (FrmKlijenti)CreateFrmKlijenti();
            frm.ShowDialog(parent);
        }

        private void FrmKlijenti_Load(object sender, EventArgs e)
        {
            try
            {
                var data = Communication.Instance.GetAllKlijent() ?? new System.Collections.Generic.List<Klijent>();
                _klijenti = new BindingList<Klijent>(data);

                var dgv = listView.dgvKlijenti;
                dgv.AutoGenerateColumns = false;
                dgv.Columns.Clear();

                dgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = nameof(Klijent.Ime),
                    HeaderText = "Ime",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });
                dgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = nameof(Klijent.Prezime),
                    HeaderText = "Prezime",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });
                dgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = nameof(Klijent.BrTelefona),
                    HeaderText = "Broj telefona",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                });
                dgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = nameof(Klijent.Mesto),
                    HeaderText = "Mesto",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });

                dgv.DataSource = _klijenti;

                RefreshMestaListForm();
                ResetListForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju klijenata: " + ex.Message);
            }
        }

        private void RefreshMestaListForm()
        {
            try
            {
                if (listView.cbMesto != null)
                {
                    var mesta = Communication.Instance.GetAllMesto() ?? new System.Collections.Generic.List<Mesto>();
                    listView.cbMesto.DataSource = new BindingList<Mesto>(mesta);
                    listView.cbMesto.DisplayMember = nameof(Mesto.Naziv);
                    listView.cbMesto.Format += (s, e) =>
                    {
                        if (e.ListItem is Mesto m) e.Value = $"{m.Naziv} ({m.Ptt})";
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju mesta: " + ex.Message);
            }
        }

        private void DgvKlijenti_SelectionChanged(object sender, EventArgs e)
        {
            if (listView.dgvKlijenti.CurrentRow?.DataBoundItem is Klijent k)
            {
                listView.tbIme.Text = k.Ime;
                listView.tbPrezime.Text = k.Prezime;
                listView.tbBrojTelefona.Text = k.BrTelefona;
                if (listView.cbMesto?.DataSource is BindingList<Mesto> ms)
                {
                    var idx = ms.ToList().FindIndex(x => x.Ptt == k.Mesto?.Ptt);
                    if (idx >= 0) listView.cbMesto.SelectedIndex = idx;
                }
            }
        }

        private void BtnDodaj_Click_List(object sender, EventArgs e)
        {
            if (!TryBuildKlijentFromForm(out var k)) return;
            try
            {
                Communication.Instance.CreateKlijent(k);
                _klijenti.Add(k);
                ResetListForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri dodavanju: " + ex.Message);
            }
        }

        private void BtnAzuriraj_Click_List(object sender, EventArgs e)
        {
            if (listView.dgvKlijenti.CurrentRow?.DataBoundItem is not Klijent sel)
            {
                MessageBox.Show("Selektuj klijenta."); return;
            }
            if (!TryBuildKlijentFromForm(out var k)) return;

            // zadrži Id selektovanog
            k.Id = sel.Id;

            try
            {
                Communication.Instance.UpdateKlijent(k); // implementiraj u Communication.cs ako fali
                // osveži lokalno
                sel.Ime = k.Ime;
                sel.Prezime = k.Prezime;
                sel.BrTelefona = k.BrTelefona;
                sel.Mesto = k.Mesto;
                listView.dgvKlijenti.Refresh();
                ResetListForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri ažuriranju: " + ex.Message);
            }
        }

        private void BtnObrisi_Click_List(object sender, EventArgs e)
        {
            if (listView.dgvKlijenti.CurrentRow?.DataBoundItem is not Klijent k)
            {
                MessageBox.Show("Selektuj klijenta."); return;
            }
            if (MessageBox.Show($"Obrisati {k.Prezime}, {k.Ime}?", "Potvrda",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            try
            {
                Communication.Instance.DeleteKlijent(k); // implementiraj u Communication.cs ako fali
                _klijenti.Remove(k);
                ResetListForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri brisanju: " + ex.Message);
            }
        }

        private bool TryBuildKlijentFromForm(out Klijent k)
        {
            k = null;
            var ime = (listView.tbIme?.Text ?? "").Trim();
            var prezime = (listView.tbPrezime?.Text ?? "").Trim();
            var tel = (listView.tbBrojTelefona?.Text ?? "").Trim();
            var mesto = listView.cbMesto?.SelectedItem as Mesto;

            if (string.IsNullOrWhiteSpace(ime)) { MessageBox.Show("Unesite ime."); listView.tbIme?.Focus(); return false; }
            if (string.IsNullOrWhiteSpace(prezime)) { MessageBox.Show("Unesite prezime."); listView.tbPrezime?.Focus(); return false; }
            if (string.IsNullOrWhiteSpace(tel)) { MessageBox.Show("Unesite broj telefona."); listView.tbBrojTelefona?.Focus(); return false; }
            if (mesto == null) { MessageBox.Show("Izaberite mesto."); listView.cbMesto.DroppedDown = true; return false; }

            k = new Klijent
            {
                Ime = ime,
                Prezime = prezime,
                BrTelefona = tel,
                Mesto = new Mesto { Ptt = mesto.Ptt }
            };
            return true;
        }

        private void ResetListForm()
        {
            listView.tbIme?.Clear();
            listView.tbPrezime?.Clear();
            listView.tbBrojTelefona?.Clear();
            if (listView.cbMesto?.Items.Count > 0) listView.cbMesto.SelectedIndex = 0;
            listView.dgvKlijenti?.ClearSelection();
            listView.dgvKlijenti.CurrentCell = null;
            listView.tbIme?.Focus();
        }
    }
}
