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
    public partial class UCDodajStavke : UserControl
    {
        public BindingList<StavkaReversa> Stavke { get; set; }
        public UCDodajStavke()
        {
            InitializeComponent();

            //UC se otvori cim se kreira revers (edituje revers)
            //na UC pise broj reversa koji je upravo kreiran
            //informacije o stavki se upisu u UC
            //na dugme "Sacuvaj" - pokupi se i validira se
            //zapise se u objekat tipa StavkaReversa
            //strpa se u binding listu "Stavke" koja je DataSource za dgvStavke
            //na dugme "Sacuvaj" se za celu listu zove SO Dodavanje stavki 
            //u toj SO foreach i dodaje se jedna po jedna stavka za taj revers
            //commit ako je sve ok, rollback ako nije :) 

            Stavke = new BindingList<StavkaReversa>();
            dgvStavke.DataSource = Stavke;

        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {

        }
    }
}
