using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Client.UserControls;
using Common.Communication;
using Domen;

namespace Client.GuiController
{
    public class RobaGuiController
    {
        // ————— Stanje —————
        private UCDodajRobu view;      // koristi se i kada radimo u FrmRoba (vežemo na ucDodajRobu1)
        private FrmRoba _frm;           // aktivna forma “Roba”
        private long? _selectedId = null;
        private Action<Roba> _onSaved;  // callback posle uspešnog snimanja (opciono)

        // ————— Public API —————

        /// UC za dodavanje robe (koristi se kada ubacujemo samo UC u glavni panel).
        public Control CreateDodajRobu(Action<Roba> onSaved = null)
        {
            view = new UCDodajRobu();

            // Event handleri (očisti pa veži)
            view.btnSacuvaj.Click -= BtnSacuvaj_Click;
            view.btnSacuvaj.Click += BtnSacuvaj_Click;

            view.btnOtkazi.Click -= BtnOtkazi_Click;
            view.btnOtkazi.Click += BtnOtkazi_Click;

            _onSaved = onSaved;
            ClearUcForm();
            return view;
        }

        /// Modalni dijalog sa UCDodajRobu (ostavljam ako ti treba)
        public DialogResult ShowDodajRobuDialog(IWin32Window owner = null, Action<Roba> onSaved = null)
        {
            var uc = CreateDodajRobu(onSaved);

            using (var frm = new Form())
            {
                frm.Text = "Dodaj robu";
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.FormBorderStyle = FormBorderStyle.FixedDialog;
                frm.MinimizeBox = false;
                frm.MaximizeBox = false;
                frm.ClientSize = new Size(520, 340);

                uc.Dock = DockStyle.Fill;
                frm.Controls.Add(uc);

                if (view?.btnSacuvaj != null) frm.AcceptButton = view.btnSacuvaj;
                if (view?.btnOtkazi != null) frm.CancelButton = view.btnOtkazi;

                return owner == null ? frm.ShowDialog() : frm.ShowDialog(owner);
            }
        }

        /// “Rad sa robom” – otvara FrmRoba i sve živo povezuje/odrađuje.
        public void ShowFrmRoba(IWin32Window owner = null)
        {
            _frm = new FrmRoba();

            // 1) mapiraj UC unutar forme kao "view" koji već koristimo
            view = _frm.ucDodajRobu1;

            // 2) Accept/Cancel preko UC dugmadi
            _frm.AcceptButton = view.btnSacuvaj;
            _frm.CancelButton = view.btnOtkazi;

            // 3) Veži evente (očisti pa veži da nema duplikata)
            view.btnSacuvaj.Click -= BtnSacuvaj_Click;
            view.btnSacuvaj.Click += BtnSacuvaj_Click;

            view.btnOtkazi.Click -= BtnOtkazi_Click;
            view.btnOtkazi.Click += BtnOtkazi_Click;

            _frm.btnAzuriraj.Click -= BtnAzuriraj_Click;
            _frm.btnAzuriraj.Click += BtnAzuriraj_Click;

            _frm.btnObrisi.Click -= BtnObrisi_Click;
            _frm.btnObrisi.Click += BtnObrisi_Click;

            _frm.dgvRoba.SelectionChanged -= DgvRoba_SelectionChanged;
            _frm.dgvRoba.SelectionChanged += DgvRoba_SelectionChanged;

            _frm.Shown -= Frm_Shown;
            _frm.Shown += Frm_Shown;

            // 4) Konfiguriši grid kolone
            ConfigureGrid(_frm.dgvRoba);

            // 5) Resetuj formu
            ClearUcForm();
            _selectedId = null;

            // 6) Otvori formu
            if (owner == null) _frm.Show();
            else _frm.Show(owner);
        }

        /// Ako ti treba samo UC za “rad sa robom” (bez forme)
        public Control CreateRadSaRobomView(Action<Roba> onSaved = null) => CreateDodajRobu(onSaved);

        // ————— Event glue —————

        private void Frm_Shown(object sender, EventArgs e) => ReloadGrid();

        private void DgvRoba_SelectionChanged(object sender, EventArgs e)
        {
            var r = GetSelected();
            if (r == null)
            {
                _selectedId = null;
                return;
            }
            _selectedId = r.Id;
            FillFormFromEntity(r);
        }

        // Sačuvaj (kreiraj novu robu)
        private void BtnSacuvaj_Click(object sender, EventArgs e)
        {
            try
            {
                if (!TryBuildRobaFromUc(out var roba)) return;

                var response = Communication.Instance.CreateRoba(roba);
                if (response.ExceptionMessage != null)
                {
                    MessageBox.Show(response.ExceptionMessage, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Roba je sačuvana.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _onSaved?.Invoke(roba);

                ReloadGrid();
                ClearUcForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnOtkazi_Click(object sender, EventArgs e) => ClearUcForm();

        // Ažuriraj selektovanu robu
        private void BtnAzuriraj_Click(object sender, EventArgs e)
        {
            if (_frm == null)
                return;

            if (_selectedId == null)
            {
                MessageBox.Show("Izaberite robu u tabeli za ažuriranje.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                if (!TryBuildRobaFromUc(out var roba)) return;
                roba.Id = _selectedId.Value;

                var response = Communication.Instance.UpdateRoba(roba);
                if (response.ExceptionMessage != null)
                {
                    MessageBox.Show(response.ExceptionMessage, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Roba je ažurirana.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ReloadGrid();
                ReselectById(roba.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Obriši selektovanu robu
        private void BtnObrisi_Click(object sender, EventArgs e)
        {
            if (_frm == null)
                return;

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
                var response = Communication.Instance.DeleteRoba(sel);
                if (response.ExceptionMessage != null)
                {
                    MessageBox.Show(response.ExceptionMessage, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Roba je obrisana.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ReloadGrid();
                ClearUcForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ————— Helperi —————

        private void ConfigureGrid(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();

            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ReadOnly = true;

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
                DefaultCellStyle =
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "0.##"
                }
            };
            dgv.Columns.Add(colCena);

            // Ako želiš da ućutkaš DataError popup:
            // dgv.DataError += (s, e) => { e.ThrowException = false; };
        }

        private void ReloadGrid()
        {
            if (_frm == null) return;

            try
            {
                var lista = Communication.Instance.GetAllRoba();
                Bind(lista);
                _frm.dgvRoba.ClearSelection();
                _frm.dgvRoba.CurrentCell = null;
                _selectedId = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška pri učitavanju", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Bind(Array.Empty<Roba>());
                _frm.dgvRoba.ClearSelection();
                _frm.dgvRoba.CurrentCell = null;
                _selectedId = null;
            }
        }

        private void Bind(IEnumerable<Roba> data)
        {
            if (_frm == null) return;
            _frm.dgvRoba.DataSource = null;
            _frm.dgvRoba.DataSource = (data ?? Enumerable.Empty<Roba>()).ToList();
        }

        private Roba GetSelected()
        {
            if (_frm?.dgvRoba?.CurrentRow == null) return null;
            return _frm.dgvRoba.CurrentRow.DataBoundItem as Roba;
        }

        private void FillFormFromEntity(Roba r)
        {
            if (view == null || r == null) return;
            view.tbNaziv.Text = r.Naziv;
            view.tbOpis.Text = r.Opis;
            view.tbCena.Text = r.Cena.ToString("0.##", CultureInfo.CurrentCulture);
        }

        private void ClearUcForm()
        {
            if (view == null) return;
            view.tbNaziv.Text = string.Empty;
            view.tbOpis.Text = string.Empty;
            view.tbCena.Text = string.Empty;
            _selectedId = null;
            view.tbNaziv.Focus();
        }

        private bool TryBuildRobaFromUc(out Roba roba)
        {
            roba = null;
            if (view == null) return false;

            string naziv = view.tbNaziv.Text?.Trim();
            string opis = view.tbOpis.Text?.Trim();
            string cenaS = view.tbCena.Text?.Trim();

            if (string.IsNullOrWhiteSpace(naziv))
            {
                MessageBox.Show("Naziv je obavezan.", "Validacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                view.tbNaziv.Focus();
                return false;
            }
            if (!TryParseDecimal(cenaS, out decimal cena) || cena < 0)
            {
                MessageBox.Show("Cena mora biti broj ≥ 0.", "Validacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                view.tbCena.Focus();
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

        private void ReselectById(long id)
        {
            if (_frm == null) return;

            foreach (DataGridViewRow row in _frm.dgvRoba.Rows)
            {
                if (row.DataBoundItem is Roba r && r.Id == id)
                {
                    row.Selected = true;
                    _frm.dgvRoba.CurrentCell = row.Cells[0];
                    break;
                }
            }
        }

        private static bool TryParseDecimal(string input, out decimal value)
        {
            if (decimal.TryParse(input, NumberStyles.Number, CultureInfo.CurrentCulture, out value)) return true;
            if (decimal.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out value)) return true;
            string swapped = input?.Replace(',', '.');
            return decimal.TryParse(swapped, NumberStyles.Number, CultureInfo.InvariantCulture, out value);
        }
    }
}
