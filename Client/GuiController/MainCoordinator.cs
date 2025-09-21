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
            try
            {
                var uc = robaGuiController.CreateDodajRobu(onSaved: null);
                frmMain.ChangePanel(uc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška pri otvaranju", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal void ShowDodajRobuDialog()
        {
            try
            {
                robaGuiController.ShowDodajRobuDialog(frmMain, onSaved: null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška pri otvaranju", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal void ShowRadSaRobom()
        {
            try
            {
                robaGuiController.ShowFrmRoba(frmMain);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška pri otvaranju", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // === KLIJENT ===
        internal void ShowDodajKlijenta()
        {
            try
            {
                klijentGuiController.ShowDodajKlijentaIn(frmMain); // centralizovani lepak
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška pri otvaranju", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal void ShowRadSaKlijentima()
        {
            try
            {
                klijentGuiController.ShowKlijentiDialog(frmMain); // dijalog sa listom klijenata
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška pri otvaranju", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // === REVERS ===
        internal void ShowAddReversPanel()
        {
            try
            {
                frmMain.ChangePanel(reversGuiController.CreateDodajRevers());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška pri otvaranju", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal void ShowRadSaReversima()
        {
            try
            {
                reversGuiController.ShowFrmPretragaReversa(frmMain);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška pri otvaranju", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // === MESTO ===
        internal void ShowRadSaMestima()
        {
            try
            {
                mestoGuiController.ShowFrmMesta(frmMain);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška pri otvaranju", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // === STRUČNA SPREMA ===
        internal void ShowRadSaStrSpremom()
        {
            try
            {
                var uc = strSpremaGuiController.CreateDodajStrSprema();
                frmMain.ChangePanel(uc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška pri otvaranju", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal void PerformLogout()
        {
            try { Communication.Instance.Logout(); } catch { }
            frmMain?.Close();
            frmMain = null;
        }
    }
}
