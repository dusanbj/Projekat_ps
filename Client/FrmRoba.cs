using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Domen;
using Client;                 // zbog Communication.Instance
using Client.UserControls;    // zbog UCDodajRobu

namespace Client
{
    public partial class FrmRoba : Form
    {
        private long? _selectedId = null;

        public FrmRoba()
        {
            InitializeComponent();

            ConfigureGrid();

            this.AcceptButton = ucDodajRobu1.btnSacuvaj;
            this.CancelButton = ucDodajRobu1.btnOtkazi;

            ucDodajRobu1.btnSacuvaj.Click += BtnSacuvaj_Click;
            ucDodajRobu1.btnOtkazi.Click += (s, e) => ClearForm();

            btnAzuriraj.Click += btnAzuriraj_Click;
            btnObrisi.Click += btnObrisi_Click;

            dgvRoba.SelectionChanged += dgvRoba_SelectionChanged;

            this.Shown += (s, e) => ReloadGrid();
        }

        private void ConfigureGrid()
        {
            var dgv = dgvRoba;

            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();

            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ReadOnly = true; // uređivanje radiš kroz formu ispod grida

            // Id
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Roba.Id),
                HeaderText = "Id",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            // Naziv
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Roba.Naziv),
                HeaderText = "Naziv",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // Opis
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Roba.Opis),
                HeaderText = "Opis",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // Cena
            var colCena = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Roba.Cena),
                HeaderText = "Cena",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "0.##" } // ili "N2"
            };
            dgv.Columns.Add(colCena);

            // da utisamo default DataError popup
            // dgv.DataError += (s, e) => { e.ThrowException = false; };
        }


        /* === Public helper za vezivanje ako ti zatreba spolja === */
        public void Bind(IEnumerable<Roba> data)
        {
            dgvRoba.DataSource = null;
            dgvRoba.DataSource = data?.ToList();
        }

        /* === GRID & SELECTION === */
        private void ReloadGrid()
        {
            try
            {
                var lista = Communication.Instance.GetAllRoba();
                Bind(lista);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška pri učitavanju", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvRoba_SelectionChanged(object sender, EventArgs e)
        {
            var r = GetSelected();
            if (r == null)
            {
                _selectedId = null;
                return;
            }
            _selectedId = r.Id;
            FillForm(r);
        }

        private Roba GetSelected()
        {
            if (dgvRoba.CurrentRow == null) return null;
            return dgvRoba.CurrentRow.DataBoundItem as Roba;
        }

        /* === FORM <-> ROBA === */
        private void FillForm(Roba r)
        {
            ucDodajRobu1.tbNaziv.Text = r.Naziv;
            ucDodajRobu1.tbOpis.Text = r.Opis;
            ucDodajRobu1.tbCena.Text = r.Cena.ToString("0.##", CultureInfo.CurrentCulture);
        }

        private void ClearForm()
        {
            ucDodajRobu1.tbNaziv.Text = string.Empty;
            ucDodajRobu1.tbOpis.Text = string.Empty;
            ucDodajRobu1.tbCena.Text = string.Empty;
            _selectedId = null;
        }

        private bool TryBuildFromForm(out Roba roba)
        {
            roba = null;
            string naziv = ucDodajRobu1.tbNaziv.Text?.Trim();
            string opis = ucDodajRobu1.tbOpis.Text?.Trim();
            string cenaS = ucDodajRobu1.tbCena.Text?.Trim();

            if (string.IsNullOrWhiteSpace(naziv))
            {
                MessageBox.Show("Naziv je obavezan.", "Validacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ucDodajRobu1.tbNaziv.Focus();
                return false;
            }
            if (!TryParseDecimal(cenaS, out decimal cena) || cena < 0)
            {
                MessageBox.Show("Cena mora biti broj ≥ 0.", "Validacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ucDodajRobu1.tbCena.Focus();
                return false;
            }

            roba = new Roba
            {
                Naziv = naziv,
                Opis = string.IsNullOrWhiteSpace(opis) ? null : opis,
                Cena = cena
            };
            return true;
        }

        private static bool TryParseDecimal(string input, out decimal value)
        {
            if (decimal.TryParse(input, NumberStyles.Number, CultureInfo.CurrentCulture, out value)) return true;
            if (decimal.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out value)) return true;
            string swapped = input?.Replace(',', '.');
            return decimal.TryParse(swapped, NumberStyles.Number, CultureInfo.InvariantCulture, out value);
        }

        /* === DUGMAD === */

        // Sačuvaj (kreiraj novu robu)
        private void BtnSacuvaj_Click(object sender, EventArgs e)
        {
            try
            {
                if (!TryBuildFromForm(out var roba)) return;

                Communication.Instance.CreateRoba(roba);
                MessageBox.Show("Roba je sačuvana.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ReloadGrid();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Ažuriraj (menja selektovani red)
        private void btnAzuriraj_Click(object sender, EventArgs e)
        {
            if (_selectedId == null)
            {
                MessageBox.Show("Izaberite robu u tabeli za ažuriranje.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                if (!TryBuildFromForm(out var roba)) return;
                roba.Id = _selectedId.Value;

                Communication.Instance.UpdateRoba(roba);
                MessageBox.Show("Roba je ažurirana.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ReloadGrid();
                ReselectById(roba.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Obriši (briše selektovani red)
        private void btnObrisi_Click(object sender, EventArgs e)
        {
            var sel = GetSelected();
            if (sel == null)
            {
                MessageBox.Show("Izaberite robu u tabeli za brisanje.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show($"Obrisati robu \"{sel.Naziv}\"?", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                Communication.Instance.DeleteRoba(sel);
                MessageBox.Show("Roba je obrisana.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ReloadGrid();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReselectById(long id)
        {
            foreach (DataGridViewRow row in dgvRoba.Rows)
            {
                if (row.DataBoundItem is Roba r && r.Id == id)
                {
                    row.Selected = true;
                    dgvRoba.CurrentCell = row.Cells[0];
                    break;
                }
            }
        }
    }
}
