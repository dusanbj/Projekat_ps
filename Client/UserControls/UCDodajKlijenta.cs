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

namespace Client.UserControls
{
    public partial class UCDodajKlijenta : UserControl
    {
        public UCDodajKlijenta()
        {
            InitializeComponent();
            BindingList<Mesto> mesta = new BindingList<Mesto>((List<Mesto>)Communication.Instance.GetAllMesto());
            cbMesto.DataSource = mesta;
            cbMesto.DisplayMember = "Naziv";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
