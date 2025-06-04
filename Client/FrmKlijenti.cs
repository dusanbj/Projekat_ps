using Domen;
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
    public partial class FrmKlijenti : Form
    {
        
        public FrmKlijenti()
        {
            InitializeComponent();
            BindingList<Mesto> mesta = new BindingList<Mesto>((List<Mesto>)Communication.Instance.GetAllCity());
            BindingList<Klijent> klijenti = new BindingList<Klijent>((List<Klijent>)Communication.Instance.GetAllKlijent());
            cbMesto.DataSource = mesta;
            cbMesto.DisplayMember = "Naziv";
            dgvKlijenti.DataSource = klijenti;
            dgvKlijenti.Columns["id"].Visible = false;
            dgvKlijenti.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


    }
}
