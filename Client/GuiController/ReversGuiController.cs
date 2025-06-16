using Client.UserControls;
using Common.Communication;
using Domen;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GuiController
{
    public class ReversGuiController
    {
        private UCDodajRevers dodajRevers;

        internal Control CreateDodajRevers()
        {
            dodajRevers = new UCDodajRevers();
            dodajRevers.btnDodaj.Click += AddRevers;
            return dodajRevers;
        }

        private void AddRevers(object sender, EventArgs e)
        {
            Klijent izabrani = dodajRevers.cmbKlijent.SelectedItem as Klijent;
            if (izabrani == null)
            {
                MessageBox.Show("Morate izabrati klijenta!");
                return;
            }
            Revers revers = new Revers
            {
                Datum = dodajRevers.danas,
                Zaposleni = LoginGuiController.Instance.z,
                Klijent = izabrani,
                Stavke = null
            };


            Response response = Communication.Instance.CreateRevers(revers);
            if (response.ExceptionMessage == null)
            {
                MessageBox.Show("Uspesno ste kreirali revers! Molimo dodajte stavke");
            }
            else
            {
                Debug.WriteLine(response.ExceptionMessage);
            }
        }



        /*
        ovako cemo:
        1. UCDodajRevers - doda revers i napravi se u bazi podataka prazan revers
        2. odmah kad se kreira revers - izbaci formu za dodavanje stavki u revers
        3. dugme dodaj dodaje stavku u revers, i potom dugme sacuvaj update revers i dodaje mu stavke
        4. ako bude revers bez stavki - uradi se rollback 


        */
    }
}
