using Client.GuiController;
using System;
using System.Windows.Forms;

namespace Client
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

            // Ovi meniji su već žičeni ka kontroleru:
            dodajKlijentaToolStripMenuItem.Click += (s, a) => MainCoordinator.Instance.ShowDodajKlijenta();
            dodajReversToolStripMenuItem.Click += (s, a) => MainCoordinator.Instance.ShowAddReversPanel();
            dodajRobuToolStripMenuItem.Click += (s, a) => MainCoordinator.Instance.ShowDodajRobuOnMain();
            radSaRobomToolStripMenuItem.Click += (s, a) => MainCoordinator.Instance.ShowRadSaRobom();

            // Rad sa klijentima neka ostane preko Designer eventa (ispod),
            // ili ako želiš i ovde lambda:
            // radSaKlijentimaToolStripMenuItem.Click += (s, a) => MainCoordinator.Instance.ShowRadSaKlijentima();
        }

        public void ChangePanel(Control control)
        {
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(control);
            control.Dock = DockStyle.Fill;
            pnlMain.AutoSize = true;
            pnlMain.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        // SADA: ovaj handler zove kontroler (više ne instancira FrmKlijenti direktno)
        private void radSaKlijentimaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainCoordinator.Instance.ShowRadSaKlijentima();
        }

        private void itemAddPerson_Click(object sender, EventArgs e)
        {
            // Ako je mapiran u Designeru, može pozivati:
            // MainCoordinator.Instance.ShowDodajKlijenta();
        }

        private void dodajKlijentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainCoordinator.Instance.ShowDodajKlijenta();
        }

        private void dodajReversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainCoordinator.Instance.ShowAddReversPanel();
        }
    }
}
