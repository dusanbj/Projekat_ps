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

namespace Client.GuiController
{
    public class PersonGuiController
    {

        //private UCAddPerson addPerson;

        //internal Control CreateAddPerson()
        //{
        //    addPerson = new UCAddPerson();
        //    addPerson.BtnAddPerson.Click += AddPerson;
        //    return addPerson;
        //}

        //private void AddPerson(object sender, EventArgs e)
        //{
        //    Person person = new Person
        //    {

        //        FirstName = addPerson.TxtFirstName.Text,
        //        LastName = addPerson.TxtLastName.Text,
        //        IsMarried = addPerson.ChbMarried.Checked,
        //        City = (City)addPerson.CmbCity.SelectedItem,
        //        Birthday = addPerson.McBirthday.SelectionStart, 
        //        Gender = (Gender)Enum.Parse(typeof(Gender), addPerson.CmbGender.SelectedItem.ToString())
        //    };
        //    Response response = Communication.Instance.CreatePerson(person);
        //    if (response.Exception == null)
        //    {
        //        MessageBox.Show("Uspesno ste dodali osobu!");
        //    }
        //    else
        //    {
        //        Debug.WriteLine(response.Exception);
        //    }
        //}

    }
}
