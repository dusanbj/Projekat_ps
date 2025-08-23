using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Domen;

namespace Client.GuiController
{
    public class MestoGuiController
    {
        private FrmMesto view;
        private bool _suppressSelectionChanged; // <— dodato

        public Form CreateFrmMesta()
        {
            view = new FrmMesto();

            view.Load += FrmMesto_Load;
            view.dgvMesta.SelectionChanged += DgvMesta_SelectionChanged;

            view.btnSacuvaj.Click += BtnSacuvaj_Click;   // samo CREATE
            view.btnAzuriraj.Click += BtnAzuriraj_Click; // samo UPDATE
            view.btnObrisi.Click += BtnObrisi_Click;

            return view;
        }

        internal void ShowFrmMesta(Form parent)
        {
            var frm = (FrmMesto)CreateFrmMesta();
            frm.ShowDialog(parent);
        }

        private void FrmMesto_Load(object sender, EventArgs e)
        {
            try
            {
                _suppressSelectionChanged = true; // <<< pauza
                view.dgvMesta.AutoGenerateColumns = true;

                var lista = Communication.Instance.GetAllMesto();
                view.dgvMesta.DataSource = new BindingList<Mesto>(lista ?? new List<Mesto>());

                ResetForme(); // postavi create-mode
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju mesta: " + ex.Message);
            }
            finally
            {
                _suppressSelectionChanged = false; // nastavi
            }
        }

        private void DgvMesta_SelectionChanged(object sender, EventArgs e)
        {
            if (_suppressSelectionChanged) return;

            // NEMA selekcije => create-mode
            var hasSelection =
                view.dgvMesta.SelectedRows.Count > 0 &&
                view.dgvMesta.CurrentRow != null &&
                view.dgvMesta.CurrentRow.Selected;

            if (!hasSelection)
            {
                // create-mode
                view.tbPtt.Enabled = true;
                return;
            }

            if (view.dgvMesta.CurrentRow?.DataBoundItem is Mesto m)
            {
                view.tbPtt.Text = m.Ptt.ToString();
                view.tbNaziv.Text = m.Naziv;
                view.tbPtt.Enabled = false; // edit-mode
            }
        }

        private void BtnSacuvaj_Click(object sender, EventArgs e)
        {
            // CREATE only
            if (string.IsNullOrWhiteSpace(view.tbNaziv.Text))
            {
                MessageBox.Show("Unesi naziv mesta.");
                view.tbNaziv.Focus();
                return;
            }
            if (!long.TryParse(view.tbPtt.Text?.Trim(), out var ptt))
            {
                MessageBox.Show("PTT mora biti broj.");
                view.tbPtt.Focus();
                return;
            }

            var ds = view.dgvMesta.DataSource as BindingList<Mesto>;
            if (ds == null)
            {
                ds = new BindingList<Mesto>();
                view.dgvMesta.DataSource = ds;
            }

            if (ds.Any(x => x.Ptt == ptt))
            {
                MessageBox.Show("Mesto sa tim PTT već postoji. Za izmene koristi 'Ažuriraj'.");
                return;
            }

            try
            {
                var model = new Mesto { Ptt = ptt, Naziv = view.tbNaziv.Text.Trim() };
                var kreirano = Communication.Instance.CreateMesto(model) ?? model;

                ds.Add(kreirano);
                MessageBox.Show("Mesto dodato.");
                ResetForme(); // vrati create-mode
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška: " + ex.Message);
            }
        }

        private void BtnAzuriraj_Click(object sender, EventArgs e)
        {
            // UPDATE only
            if (view.dgvMesta.CurrentRow?.DataBoundItem is not Mesto selektovano)
            {
                MessageBox.Show("Selektuj red koji želiš da izmeniš.");
                return;
            }
            if (string.IsNullOrWhiteSpace(view.tbNaziv.Text))
            {
                MessageBox.Show("Unesi naziv mesta.");
                view.tbNaziv.Focus();
                return;
            }

            try
            {
                selektovano.Naziv = view.tbNaziv.Text.Trim();
                Communication.Instance.UpdateMesto(selektovano);
                view.dgvMesta.Refresh();
                MessageBox.Show("Mesto ažurirano.");
                ResetForme(); // vrati create-mode
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri ažuriranju: " + ex.Message);
            }
        }

        private void BtnObrisi_Click(object sender, EventArgs e)
        {
            if (view.dgvMesta.CurrentRow?.DataBoundItem is not Mesto m)
            {
                MessageBox.Show("Selektuj red.");
                return;
            }

            if (MessageBox.Show($"Obrisati {m.Naziv} ({m.Ptt})?",
                                "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                Communication.Instance.DeleteMesto(m);

                if (view.dgvMesta.DataSource is BindingList<Mesto> ds)
                    ds.Remove(m);
                else
                    view.dgvMesta.DataSource = new BindingList<Mesto>();

                ResetForme(); // vrati create-mode
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri brisanju: " + ex.Message);
            }
        }

        private void ResetForme()
        {
            view.tbPtt.Enabled = true;
            view.tbPtt.Clear();
            view.tbNaziv.Clear();

            _suppressSelectionChanged = true;     // <<< spreči lažni event
            view.dgvMesta.ClearSelection();
            view.dgvMesta.CurrentCell = null;     // <<< ključni trik
            _suppressSelectionChanged = false;

            view.tbPtt.Focus();
        }
    }
}
