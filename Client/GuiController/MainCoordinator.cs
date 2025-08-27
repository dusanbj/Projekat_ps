using System;
using System.Windows.Forms;

namespace Client.GuiController
{
    // kontrolise sta se desava na mainu kad klikcemo po meniju
    internal class MainCoordinator
    {
        private static MainCoordinator instance;
        public static MainCoordinator Instance
        {
            get
            {
                if (instance == null) instance = new MainCoordinator();
                return instance;
            }
        }

        private MainCoordinator()
        {
            klijentGuiController = new KlijentGuiController();
            reversGuiController = new ReversGuiController();
            robaGuiController = new RobaGuiController();
            mestoGuiController = new MestoGuiController();
            strSpremaGuiController = new StrSpremaGuiController();
        }

        private FrmMain frmMain;
        private readonly KlijentGuiController klijentGuiController;
        private readonly ReversGuiController reversGuiController;
        private readonly RobaGuiController robaGuiController;
        private readonly MestoGuiController mestoGuiController;
        private readonly StrSpremaGuiController strSpremaGuiController;

        public Form MainForm => frmMain;

        internal void ShowFrmMain()
        {
            frmMain = new FrmMain
            {
                AutoSize = true,
                StartPosition = FormStartPosition.CenterScreen
            };

            // Postavi tekst iz LoginGuiController-a
            var z = LoginGuiController.Instance.Z;
            if (z != null)
            {
                frmMain.SetZaposleniCaption($"{z.Ime} {z.Prezime}");
            }

            frmMain.ShowDialog();
        }


        // === ROBA ===
        internal void ShowDodajRobuOnMain()
        {
            var uc = robaGuiController.CreateDodajRobu(onSaved: null);
            frmMain.ChangePanel(uc);
        }

        internal void ShowDodajRobuDialog()
        {
            robaGuiController.ShowDodajRobuDialog(frmMain, onSaved: null);
        }

        internal void ShowRadSaRobom()
        {
            robaGuiController.ShowFrmRoba(frmMain);
        }

        // === KLIJENT ===
        internal void ShowDodajKlijenta()
        {
            frmMain.ChangePanel(klijentGuiController.CreateDodajKlijenta());
        }

        internal void ShowRadSaKlijentima()
        {
            klijentGuiController.ShowFrmKlijenti(frmMain);
        }

        // === REVERS ===
        internal void ShowAddReversPanel()
        {
            frmMain.ChangePanel(reversGuiController.CreateDodajRevers());
        }

        // === MESTO ===
        internal void ShowRadSaMestima()
        {
            mestoGuiController.ShowFrmMesta(frmMain);
        }

        // === STRUČNA SPREMA ===
        internal void ShowRadSaStrSpremom()
        {
            var uc = strSpremaGuiController.CreateDodajStrSprema();
            frmMain.ChangePanel(uc);
        }

        internal void PerformLogout()
        {
            try { Communication.Instance.Logout(); } catch { }
            frmMain?.Close();
            frmMain = null;
        }
    }
}
