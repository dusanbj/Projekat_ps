using Client.UserControls;
using Common.Communication;
using Domen;
using System;
using System.Windows.Forms;

namespace Client.GuiController
{
    public class StrSpremaGuiController
    {
        private UCDodajStrSpremu view;

        // 1) Ako želiš da ga ugradis u panel/tab – ovo vratiš iz MainCoordinator-a
        internal Control CreateDodajStrSprema()
        {
            view = new UCDodajStrSpremu();
            WireUp(view);
            return view;
        }

        // 2) Ako želiš poseban prozor (modal) – pozovi iz MainCoordinator-a
        internal void ShowDodajStrSprema(Form parent = null)
        {
            var uc = new UCDodajStrSpremu();
            WireUp(uc);

            using var f = new Form
            {
                Text = "Dodaj stručnu spremu",
                StartPosition = FormStartPosition.CenterParent,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                MinimizeBox = false,
                MaximizeBox = false
            };
            uc.Dock = DockStyle.Fill;
            f.Controls.Add(uc);

            if (parent != null) f.ShowDialog(parent);
            else f.ShowDialog();
        }

        private void WireUp(UCDodajStrSpremu uc)
        {
            uc.Load += (_, __) => uc.tbNaziv.Focus();
            uc.btnDodaj.Click += (s, e) => Add(uc);
            uc.tbNaziv.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) { Add(uc); e.Handled = true; }
            };
        }

        private void Add(UCDodajStrSpremu uc)
        {
            var naziv = (uc.tbNaziv.Text ?? string.Empty).Trim();
            if (naziv.Length == 0)
            {
                MessageBox.Show("Unesite naziv stručne spreme.", "Validacija",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                uc.tbNaziv.Focus();
                return;
            }

            try
            {
                var ss = new StrSprema { Naziv = naziv };
                var resp = Communication.Instance.CreateStrSprema(ss);
                if (resp.ExceptionMessage != null) throw new Exception(resp.ExceptionMessage);

                MessageBox.Show("Stručna sprema je sačuvana.", "OK",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                uc.tbNaziv.Clear();
                uc.tbNaziv.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška: " + ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
