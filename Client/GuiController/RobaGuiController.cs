using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Client.UserControls;
using Common.Communication;
using Domen;

namespace Client.GuiController
{
    public class RobaGuiController
    {
        private UCDodajRobu view;
        private Action<Roba> _onSaved;

        /// <summary>
        /// Kreira i vraća UserControl za dodavanje robe, uz opcionu onSaved akciju
        /// (npr. za osvežavanje grida nakon uspešnog snimanja).
        /// </summary>
        public Control CreateDodajRobu(Action<Roba> onSaved = null)
        {
            view = new UCDodajRobu();

            // Event handler-i (osiguramo da nema duplog vezivanja)
            view.btnSacuvaj.Click -= BtnSacuvaj_Click;
            view.btnSacuvaj.Click += BtnSacuvaj_Click;

            view.btnOtkazi.Click -= BtnOtkazi_Click;
            view.btnOtkazi.Click += BtnOtkazi_Click;

            _onSaved = onSaved;
            ClearForm();
            return view;
        }

        /// <summary>
        /// Otvara modalni prozor sa UCDodajRobu.
        /// </summary>
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

                // Enter/Esc
                if (view.btnSacuvaj != null) frm.AcceptButton = view.btnSacuvaj;
                if (view.btnOtkazi != null) frm.CancelButton = view.btnOtkazi;

                return owner == null ? frm.ShowDialog() : frm.ShowDialog(owner);
            }
        }

        /// <summary>
        /// Vraća UC za rad sa robom koji možemo ubaciti u FrmMain.
        /// (Za sada vraća UCDodajRobu; kasnije dodajemo DataGridView.)
        /// </summary>
        public Control CreateRadSaRobomView(Action<Roba> onSaved = null)
        {
            return CreateDodajRobu(onSaved);
        }

        private void BtnOtkazi_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        public void ShowFrmRoba(IWin32Window owner = null)
        {
            var frm = new FrmRoba(); 
            if (owner == null) frm.Show();
            else frm.Show(owner);
        }


        private void BtnSacuvaj_Click(object sender, EventArgs e)
        {
            try
            {
                if (!TryBuildRoba(out var roba))
                    return; // poruka je već prikazana

                // Poziv serveru – očekuje se da Communication ima CreateRoba i vraća Response
                var response = Communication.Instance.CreateRoba(roba);
                if (response.ExceptionMessage != null)
                {
                    MessageBox.Show(response.ExceptionMessage, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Roba je uspešno sačuvana.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Callback (npr. osvežavanje liste)
                _onSaved?.Invoke(roba);

                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Validacija i kreiranje Roba objekta iz polja forme.
        /// </summary>
        private bool TryBuildRoba(out Roba roba)
        {
            roba = null;

            string naziv = view.tbNaziv.Text?.Trim() ?? string.Empty;
            string opis = view.tbOpis.Text?.Trim() ?? string.Empty;
            string cenaStr = view.tbCena.Text?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(naziv))
            {
                MessageBox.Show("Naziv je obavezan.", "Validacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                view.tbNaziv.Focus();
                return false;
            }

            if (!TryParseDecimal(cenaStr, out decimal cena) || cena < 0)
            {
                MessageBox.Show("Cena mora biti ispravan broj veći ili jednak 0.", "Validacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        /// <summary>
        /// Pokušava parsiranje decimalnog broja i sa lokalnim i sa invariant formatom.
        /// Dozvoljava i unos sa tačkom i sa zarezom.
        /// </summary>
        private static bool TryParseDecimal(string input, out decimal value)
        {
            if (decimal.TryParse(input, NumberStyles.Number, CultureInfo.CurrentCulture, out value)) return true;
            if (decimal.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out value)) return true;

            string swapped = input?.Replace(',', '.');
            return decimal.TryParse(swapped, NumberStyles.Number, CultureInfo.InvariantCulture, out value);
        }

        private void ClearForm()
        {
            view.tbNaziv.Text = string.Empty;
            view.tbOpis.Text = string.Empty;
            view.tbCena.Text = string.Empty;
            view.tbNaziv.Focus();
        }
    }
}
