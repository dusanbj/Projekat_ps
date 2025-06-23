using Client.UserControls;
using Common.Communication;
using Domen;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GuiController
{
    public class ReversGuiController
    {
        private UCDodajRevers dodajRevers;
        private UCDodajStavke dodajStavke;
        Form forma;
        private Revers revers;
        

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
            revers = new Revers
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
                forma = new Form();
                forma.Text = "Dodavanje stavki";
                forma.Size = new Size(600, 400);

                dodajStavke = new UCDodajStavke();
                dodajStavke.Dock = DockStyle.Fill;
                forma.Controls.Add(dodajStavke);

                dodajStavke.btnDodaj.Click += AddStavke;
                dodajStavke.btnSacuvaj.Click += SacuvajStavke;

                forma.ShowDialog();

            }
            else
            {
                Debug.WriteLine(response.ExceptionMessage);
            }
        }

        private void SacuvajStavke(object sender, EventArgs e)
        {
            if (dodajStavke.Stavke == null || dodajStavke.Stavke.Count == 0)
            {
                MessageBox.Show("Revers mora sadržati barem jednu stavku!");

                // Rollback ako revers nema stavki
                Communication.Instance.DeleteRevers(revers);
                return;
            }

            revers.Stavke = dodajStavke.Stavke.ToList();

            Response response = Communication.Instance.UpdateRevers(revers);
            if (response.ExceptionMessage == null)
            {
                MessageBox.Show("Revers i stavke su uspešno sačuvani!");

                // zatvori formu ako imaš referencu na nju (možda kroz event ili prosleđenu referencu)
                forma.Close();
            }
            else
            {
                MessageBox.Show("Greška prilikom čuvanja: " + response.ExceptionMessage);
            }
        }

        private void AddStavke(Object sender, EventArgs e)
        {
            if (dodajStavke.cmbRoba.SelectedItem == null ||
                !decimal.TryParse(dodajStavke.tbKolicina.Text, out decimal kolicina) || kolicina <= 0)
            {
                MessageBox.Show("Unesite validnu robu i količinu!");
                return;
            }

            Roba roba = dodajStavke.cmbRoba.SelectedItem as Roba;

            StavkaReversa stavka = new StavkaReversa
            {
                Kolicina = kolicina,
                Revers = revers,
                Roba = roba,
                IznosStavke = kolicina * roba.Cena
            };

            dodajStavke.Stavke.Add(stavka);
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
