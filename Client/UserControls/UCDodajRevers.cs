using Domen;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Client.UserControls
{
    public partial class UCDodajRevers : UserControl
    {
        public BindingList<Klijent> Klijenti { get; private set; }
        public DateTime danas;

        // Kontroler se kači na ovaj event i radi učitavanje
        public event EventHandler ViewLoaded;

        public UCDodajRevers()
        {
            InitializeComponent();

            // Prosleđujemo WinForms Load u naš custom event
            this.Load += (s, e) => ViewLoaded?.Invoke(this, EventArgs.Empty);
        }

        // “Bind” metode koje kontroler zove (UC ne zove servise!)
        public void BindKlijenti(BindingList<Klijent> klijenti)
        {
            Klijenti = klijenti ?? new BindingList<Klijent>();
 //           cmbKlijent.ValueMember = "Id";

            cmbKlijent.DataSource = Klijenti;
            cmbKlijent.DropDownStyle = ComboBoxStyle.DropDown;
            cmbKlijent.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbKlijent.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        public void SetDatum(DateTime date)
        {
            danas = date.Date;
            lblDatum.Text = danas.ToString("dd.MM.yyyy.");
        }

        public void SetZaposleni(Zaposleni z)
        {
            if (z == null)
            {
                lblZaposleni.Text = "/";
                return;
            }

            string ime = z.Ime ?? string.Empty;
            string prezime = z.Prezime ?? string.Empty;

            string prikaz = (ime + " " + prezime).Trim();
            lblZaposleni.Text = string.IsNullOrWhiteSpace(prikaz) ? "/" : prikaz;
        }


        // Dugme je “prazno” – kontroler je već subscribe-ovan na Click
        private void btnDodaj_Click(object sender, EventArgs e) { }
    }
}
