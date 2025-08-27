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
        }

        public void ChangePanel(Control control)
        {
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(control);
            control.Dock = DockStyle.Fill;
            pnlMain.AutoSize = true;
            pnlMain.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

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

        private void radSaMestimaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainCoordinator.Instance.ShowRadSaMestima();
        }

        private void dodajStrucnuSpremuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainCoordinator.Instance.ShowRadSaStrSpremom();
        }

        //setter za tekst menija "zaposleni"
        public void SetZaposleniCaption(string naziv)
        {
            zaposleniToolStripMenuItem.Text = $"Sesija: {naziv}";
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Da li ste sigurni da želite da se odjavite?",
                "Potvrda odjave",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                MainCoordinator.Instance.PerformLogout();
            }
        }
    }
}
