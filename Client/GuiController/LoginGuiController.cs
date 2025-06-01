using Common.Communication;
using Common.Domain;
using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GuiController
{
    public class LoginGuiController
    {

        private static LoginGuiController instance;
        public static LoginGuiController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoginGuiController();
                }
                return instance;
            }
        }
        private LoginGuiController()
        {
        }

        private FrmLogin frmLogin;

        internal void ShowFrmLogin()
        {
            try
            {
                Communication.Instance.Connect();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                frmLogin = new FrmLogin();
                frmLogin.AutoSize = true;
                Application.Run(frmLogin);
            }
            catch (SocketException)
            {
                MessageBox.Show("Nije moguce uspostaviti komunikaciju sa serverom!");
            }
        }

        public void Login(object sender, EventArgs e)
        {
            if (!frmLogin.Validacija())
            {
                MessageBox.Show("Molimo popunite sva polja.");
                return;
            }

            Zaposleni z = new Zaposleni
            {
                Username = frmLogin.TxtUsername.Text,
                Password = frmLogin.TxtPassword.Text,
            };
            Response response = Communication.Instance.Login(z);
            if (response.ExceptionMessage == null)
            {
                frmLogin.Visible = false;
                MainCoordinator.Instance.ShowFrmMain();
            }
            else
            {
                MessageBox.Show(">>>" + response.ExceptionMessage);
            }
        }
    }
}