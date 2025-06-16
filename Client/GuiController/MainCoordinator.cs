using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GuiController
{

    //kontrolise valjda sta se desava na mainu kad klikces po padajucem meniju, ima smisla
    internal class MainCoordinator
    {
        private static MainCoordinator instance;
        public static MainCoordinator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainCoordinator();
                }
                return instance;
            }
        }

        private MainCoordinator()
        {
            klijentGuiController = new KlijentGuiController();
            reversGuiController = new ReversGuiController();
        }

        private FrmMain frmMain;
        private KlijentGuiController klijentGuiController;
        private ReversGuiController reversGuiController;

        internal void ShowFrmMain()
        {
            frmMain = new FrmMain();
            frmMain.AutoSize = true;
            frmMain.ShowDialog();
        }

        internal void ShowDodajKlijenta()
        {
           frmMain.ChangePanel(klijentGuiController.CreateDodajKlijenta());
        }

        internal void ShowAddReversPanel()
        {
            frmMain.ChangePanel(reversGuiController.CreateDodajRevers());
            //ovde baca exception, proveriti sta se ovde desava
        }
        //internal void ShowRadSaKlijentima()
        //{
        //    frmMain.ChangePanel(klijentGuiController.CreateAddPerson());
        //}

    }
}
