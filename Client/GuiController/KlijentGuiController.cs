using Client.UserControls;
using Common.Communication;
using Common.Domain;
using Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domen;

namespace Client.GuiController
{
    public class KlijentGuiController
    {

        private UCDodajKlijenta dodajKlijenta;
       // private FrmKlijenti frmKlijenti;

        internal Control CreateAddPerson()
        {
            dodajKlijenta = new UCDodajKlijenta();
            dodajKlijenta.btnDodaj.Click += AddPerson;
            return dodajKlijenta;
        }

        //internal Control PokaziKlijente()
        //{
            
        //}

        private void AddPerson(object sender, EventArgs e)
        {
            Klijent klijent = new Klijent
            {

                //Ime = dodajKlijenta.TxtFirstName.Text,
                //LastName = dodajKlijenta.TxtLastName.Text,
                //IsMarried = dodajKlijenta.ChbMarried.Checked,
                //City = (City)dodajKlijenta.CmbCity.SelectedItem,
                //Birthday = dodajKlijenta.McBirthday.SelectionStart,
                //Gender = (Gender)Enum.Parse(typeof(Gender), dodajKlijenta.CmbGender.SelectedItem.ToString())
            };
            Response response = Communication.Instance.CreatePerson(klijent);
            //if (response.Exception == null)
            //{
            //    MessageBox.Show("Uspesno ste dodali osobu!");
            //}
            //else
            //{
            //    Debug.WriteLine(response.Exception);
            //}
        }

    }
}
