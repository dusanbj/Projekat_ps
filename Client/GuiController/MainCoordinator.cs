using System.Windows.Forms;

namespace Client.GuiController
{
    // kontrolise sta se desava na mainu kad klikces po meniju
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
            robaGuiController = new RobaGuiController();
        }

        private FrmMain frmMain;
        private KlijentGuiController klijentGuiController;
        private ReversGuiController reversGuiController;
        private readonly RobaGuiController robaGuiController;

        internal void ShowFrmMain()
        {
            frmMain = new FrmMain
            {
                AutoSize = true
            };
            // Ako želiš da glavna forma ne blokira nit, koristi Show();
            // ovde ostavljam kao do sada:
            frmMain.ShowDialog();
        }

        /// <summary>
        /// Dodaj robu -> prikazuje SAMO UCDodajRobu u centralnom panelu FrmMain.
        /// (PREVEŽI meni item u FrmMain da zove ovu metodu.)
        /// </summary>
        internal void ShowDodajRobuOnMain()
        {
            var uc = robaGuiController.CreateDodajRobu(onSaved: null);
            frmMain.ChangePanel(uc);
        }

        /// <summary>
        /// (Ostavljeno ako ti negde treba modalni dijalog za dodavanje.)
        /// </summary>
        internal void ShowDodajRobuDialog()
        {
            robaGuiController.ShowDodajRobuDialog(frmMain, onSaved: null);
        }

        /// <summary>
        /// Rad sa robom -> otvara tvoj FrmRoba (UC + DGV).
        /// </summary>
        internal void ShowRadSaRobom()
        {
            robaGuiController.ShowFrmRoba(frmMain);
        }

        internal void ShowDodajKlijenta()
        {
            frmMain.ChangePanel(klijentGuiController.CreateDodajKlijenta());
        }

        internal void ShowAddReversPanel()
        {
            frmMain.ChangePanel(reversGuiController.CreateDodajRevers());
        }

        // Rad sa klijentima ide isključivo preko kontrolera
        internal void ShowRadSaKlijentima()
        {
            using (var frmKlijenti = new FrmKlijenti())
            {
                frmKlijenti.ShowDialog(frmMain);
            }
        }
    }
}
