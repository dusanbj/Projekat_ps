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
            mestoGuiController = new MestoGuiController();
        }

        private FrmMain frmMain;
        private KlijentGuiController klijentGuiController;
        private ReversGuiController reversGuiController;
        private readonly RobaGuiController robaGuiController;
        private MestoGuiController mestoGuiController;

        internal void ShowFrmMain()
        {
            frmMain = new FrmMain
            {
                AutoSize = true
            };
            // Ako želimo da glavna forma ne blokira nit, koristi Show();
            // za sada nek bude ovo:
            frmMain.ShowDialog();
        }

        /// Dodaj robu -> prikazuje SAMO UCDodajRobu u centralnom panelu FrmMain.
        /// (PREVEŽI meni item u FrmMain da zove ovu metodu.)
        internal void ShowDodajRobuOnMain()
        {
            var uc = robaGuiController.CreateDodajRobu(onSaved: null);
            frmMain.ChangePanel(uc);
        }

        internal void ShowDodajRobuDialog()
        {
            robaGuiController.ShowDodajRobuDialog(frmMain, onSaved: null);
        }

        /// Rad sa robom -> otvara tvoj FrmRoba (UC + DGV).
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
            klijentGuiController.ShowFrmKlijenti(frmMain);
        }

        // Rad sa mestima – otvara FrmMesta kao novu formu (modalno)
        internal void ShowRadSaMestima()
        {
            mestoGuiController.ShowFrmMesta(frmMain);
        }
    }
}
