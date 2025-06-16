using Client.GuiController;
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
    public partial class UCDodajRevers : UserControl
    {
        private BindingList<Klijent> klijenti;
        public DateTime danas;
        public UCDodajRevers()
        {
            InitializeComponent();
        }

        private void UCDodajRevers_Load(object sender, EventArgs e)
        {

            klijenti = new BindingList<Klijent>((List<Klijent>)Communication.Instance.GetAllKlijent());
            danas = DateTime.Today;
            lblDatum.Text = danas.ToString("dd.MM.yyyy.");
            lblZaposleni.Text = LoginGuiController.Instance.z.Ime;
            cmbKlijent.DisplayMember = "ToString";
            cmbKlijent.ValueMember = "Id";
            cmbKlijent.DataSource = klijenti;
            cmbKlijent.DropDownStyle = ComboBoxStyle.DropDown;
            cmbKlijent.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbKlijent.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
           

        }


    }
}
