using Client.UserControls;
using Domen;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Client.GuiController
{
    public class KlijentGuiController
    {
        // ============ UC Dodaj Klijenta ============
        private UCDodajKlijenta view;
        private bool _suppressSelectionChanged; // sprečava MB poruke tokom reload-a

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

            // ODMAH napuni combobox (sa “fazon” try/catch)
            RefreshMesta_UC();

            return view;
        }

        // centralizovano ubacivanje UC-a na main panel (sa try/catch)
        public void ShowDodajKlijentaIn(Form mainForm)
        {
            try
            {
                var uc = CreateDodajKlijenta();
                uc.Dock = DockStyle.Fill;
                if (mainForm is FrmMain fm)
                    fm.ChangePanel(uc);
                else
                {
                    mainForm.Controls.Clear();
                    mainForm.Controls.Add(uc);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška pri otvaranju", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SubmitOnEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                view.btnSacuvaj.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void BtnDodajGrad_Click(object sender, EventArgs e)
        {
            try
            {
                MainCoordinator.Instance.ShowRadSaMestima();
                RefreshMesta_UC();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška pri otvaranju rada sa mestima",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // “fazon try/catch” za UC combobox
        private void RefreshMesta_UC()
        {
            try
            {
                var lista = Communication.Instance.GetAllMesto() ?? new List<Mesto>();
                var ds = new BindingList<Mesto>(lista);
                view.cbMesto.DataSource = ds;
                view.cbMesto.DisplayMember = nameof(Mesto.Naziv);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška pri učitavanju", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool TrySaveNewKlijent(Klijent k)
        {
            try
            {
                Communication.Instance.CreateKlijent(k);
                MessageBox.Show("Sistem je zapamtio klijenta");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška pri dodavanju klijenta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // UC: Dodaj klijenta
        private void AddKlijent(object sender, EventArgs e)
        {
            try
            {
                var ime = (view.tbIme.Text ?? "").Trim();
                var prezime = (view.tbPrezime.Text ?? "").Trim();
                var tel = (view.tbBrojTelefona.Text ?? "").Trim();
                var mesto = view.cbMesto.SelectedItem as Mesto;

                if (string.IsNullOrWhiteSpace(ime))
                { MessageBox.Show("Unesite ime."); view.tbIme.Focus(); return; }
                if (string.IsNullOrWhiteSpace(prezime))
                { MessageBox.Show("Unesite prezime."); view.tbPrezime.Focus(); return; }
                if (string.IsNullOrWhiteSpace(tel))
                { MessageBox.Show("Unesite broj telefona."); view.tbBrojTelefona.Focus(); return; }
                if (mesto == null)
                { MessageBox.Show("Izaberite mesto."); view.cbMesto.DroppedDown = true; return; }

                var klijent = new Klijent
                {
                    Ime = ime,
                    Prezime = prezime,
                    BrTelefona = tel,
                    // VAŽNO: čuvamo ceo objekat mesta (da imamo i Naziv i Ptt)
                    Mesto = mesto
                };

                if (TrySaveNewKlijent(klijent))
                    ResetUcForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška pri dodavanju klijenta", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // ============ FORMA / LISTA KLIJENATA ============
        private FrmKlijenti listView;
        private BindingList<Klijent> _klijenti;

        public Form CreateFrmKlijenti()
        {
            listView = new FrmKlijenti();

            listView.Load += FrmKlijenti_Load;
            listView.dgvKlijenti.SelectionChanged += DgvKlijenti_SelectionChanged;

            listView.btnSacuvaj.Click += BtnDodaj_Click_List;
            listView.btnAzuriraj.Click += BtnAzuriraj_Click_List;
            listView.btnObrisi.Click += BtnObrisi_Click_List;

            listView.btnPretrazi.Click += BtnPretrazi_Click_List;
            listView.tbFilter.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) BtnPretrazi_Click_List(s, e);
            };

            return listView;
        }

        // try/catch da i poziv iz MainCoordinator-a bude “bezbedan”
        internal void ShowFrmKlijenti(Form parent)
        {
            try
            {
                using var frm = (FrmKlijenti)CreateFrmKlijenti();
                frm.ShowDialog(parent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška pri otvaranju", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ShowKlijentiDialog(IWin32Window owner)
        {
            try
            {
                using var frm = (FrmKlijenti)CreateFrmKlijenti();
                frm.ShowDialog(owner);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška pri otvaranju", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmKlijenti_Load(object sender, EventArgs e)
        {
            // 1) kolone grida (bez auto-generisanja)
            var dgv = listView.dgvKlijenti;
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();

            var colId = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Klijent.Id),
                HeaderText = "Id",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                Visible = false
            };
            dgv.Columns.Add(colId);

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
                DataPropertyName = nameof(Klijent.MestoPrikaz),
                HeaderText = "Mesto",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // 2) punjenje grida (sa “fazon” try/catch)
            ReloadKlijentiGrid();

            // 3) punjenje combobox-a mesta (sa “fazon” try/catch)
            RefreshMesta_ListForm();

            ResetListForm();
        }

        private void ReloadKlijentiGrid()
        {
            try
            {
                _suppressSelectionChanged = true;

                var data = Communication.Instance.GetAllKlijent() ?? new List<Klijent>();
                _klijenti = new BindingList<Klijent>(data);
                listView.dgvKlijenti.DataSource = _klijenti;

                listView.dgvKlijenti.ClearSelection();
                listView.dgvKlijenti.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška pri učitavanju", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _klijenti = new BindingList<Klijent>(new List<Klijent>());
                listView.dgvKlijenti.DataSource = _klijenti;
            }
            finally
            {
                _suppressSelectionChanged = false;
            }
        }


        private void RefreshMesta_ListForm()
        {
            try
            {
                var mesta = Communication.Instance.GetAllMesto() ?? new List<Mesto>();
                listView.cbMesto.DataSource = new BindingList<Mesto>(mesta);
                listView.cbMesto.DisplayMember = nameof(Mesto.Naziv);
                listView.cbMesto.Format += (s, e) =>
                {
                    if (e.ListItem is Mesto m) e.Value = $"{m.Naziv} ({m.Ptt})";
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška pri učitavanju", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listView.cbMesto.DataSource = new BindingList<Mesto>(new List<Mesto>());
            }
        }

        private void DgvKlijenti_SelectionChanged(object sender, EventArgs e)
        {
            if (_suppressSelectionChanged) return;

            try
            {
                var row = listView.dgvKlijenti.CurrentRow;
                if (row?.DataBoundItem is Klijent selected)
                {
                    var svezi = Communication.Instance.GetKlijent(selected.Id.ToString());
                    var k = svezi != null && svezi.Count > 0 ? svezi[0] : null;
                    if (k == null)
                    {
                        MessageBox.Show("Sistem ne može da nađe klijenta");
                        return;
                    }

                    listView.tbIme.Text = k.Ime;
                    listView.tbPrezime.Text = k.Prezime;
                    listView.tbBrojTelefona.Text = k.BrTelefona;

                    if (listView.cbMesto?.DataSource is BindingList<Mesto> ms)
                    {
                        var idx = ms.ToList().FindIndex(x => x.Ptt == k.Mesto?.Ptt);
                        if (idx >= 0) listView.cbMesto.SelectedIndex = idx;
                    }

                    MessageBox.Show("Sistem je našao klijenta");
                }
            }
            catch
            {
                MessageBox.Show("Sistem ne može da nađe klijenta");
            }
        }



        private void BtnDodaj_Click_List(object sender, EventArgs e)
        {
            if (!TryBuildKlijentFromForm(out var k)) return;
            try
            {
                if (TrySaveNewKlijent(k))
                {
                    // VAŽNO: povuci sveže iz baze (da dobijemo Id i ispravan MestoPrikaz)
                    ReloadKlijentiGrid();
                    ResetListForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška pri dodavanju", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAzuriraj_Click_List(object sender, EventArgs e)
        {
            if (listView.dgvKlijenti.CurrentRow?.DataBoundItem is not Klijent sel)
            { MessageBox.Show("Selektuj klijenta."); return; }

            if (!TryBuildKlijentFromForm(out var k)) return;

            k.Id = sel.Id;

            try
            {
                Communication.Instance.UpdateKlijent(k);

                // najcistije: reload da MestoPrikaz sigurno bude ažuran
                ReloadKlijentiGrid();
                MessageBox.Show("Sistem je zapamtio klijenta");
                ResetListForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistem ne može da zapamti klijenta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnObrisi_Click_List(object sender, EventArgs e)
        {
            if (listView.dgvKlijenti.CurrentRow?.DataBoundItem is not Klijent k)
            { MessageBox.Show("Selektuj klijenta."); return; }

            if (MessageBox.Show($"Obrisati {k.Prezime}, {k.Ime}?", "Potvrda",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            try
            {
                _suppressSelectionChanged = true;               // <<< ugasi SelectionChanged
                Communication.Instance.DeleteKlijent(k);
                _klijenti.Remove(k);                            // trigeruje SelectionChanged → ugaseno vec
                MessageBox.Show("Sistem je obrisao klijenta");
                ResetListForm();
                listView.dgvKlijenti.ClearSelection();
                listView.dgvKlijenti.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistem ne može da obriše klijenta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _suppressSelectionChanged = false;              // ponovo dozvoli evente
            }
        }

        private void BtnPretrazi_Click_List(object sender, EventArgs e)
        {
            try
            {
                _suppressSelectionChanged = true;

                var q = (listView.tbFilter?.Text ?? string.Empty).Trim();
                var results = Communication.Instance.GetKlijent(string.IsNullOrWhiteSpace(q) ? null : q);

                _klijenti = new BindingList<Klijent>(results ?? new List<Klijent>());
                listView.dgvKlijenti.DataSource = _klijenti;

                listView.dgvKlijenti.ClearSelection();
                listView.dgvKlijenti.CurrentCell = null;

                listView.tbIme.Clear();
                listView.tbPrezime.Clear();
                listView.tbBrojTelefona.Clear();
                if (listView.cbMesto.Items.Count > 0) listView.cbMesto.SelectedIndex = 0;

                // ⇩ poruke po uslovu
                if (_klijenti != null && _klijenti.Count > 0)
                    MessageBox.Show("Sistem je našao klijente po zadatim kriterijimima");
                else
                    MessageBox.Show("Sistem nije našao klijente po zadatim kriterijimima");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška pri pretrazi klijenata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _suppressSelectionChanged = false;
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
                // VAŽNO: prosleđujemo ceo objekat Mesto (ne samo Ptt)
                Mesto = mesto
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
