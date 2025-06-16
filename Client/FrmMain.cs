using Client.GuiController;
using Client.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            dodajKlijentaToolStripMenuItem.Click += (s, a) => MainCoordinator.Instance.ShowDodajKlijenta();
            dodajReversToolStripMenuItem.Click += (s, a) => MainCoordinator.Instance.ShowAddReversPanel();
            
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
            FrmKlijenti frmKlijenti = new FrmKlijenti();
            frmKlijenti.ShowDialog();
            //trebalo bi kontroler koristiti i za ovo
        }

        private void itemAddPerson_Click(object sender, EventArgs e)
        {

        }

        private void dodajKlijentaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dodajReversToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
