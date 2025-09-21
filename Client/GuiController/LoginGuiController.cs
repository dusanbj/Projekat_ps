using Common.Communication;
using Common.Domain;
using Domen;
using System;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Client.GuiController
{
    public class LoginGuiController
    {
        public Zaposleni Z { get; set; }

        private static LoginGuiController instance;
        public static LoginGuiController Instance
        {
            get
            {
                if (instance == null) instance = new LoginGuiController();
                return instance;
            }
        }
        private LoginGuiController() { }

        private FrmLogin frmLogin;

        // Kontekst koji "čeka server" i prikazuje login tek kad se veza uspostavi
        private sealed class AwaitServerContext : ApplicationContext
        {
            private readonly LoginGuiController owner;
            private readonly Timer timer;
            private bool connecting;

            public AwaitServerContext(LoginGuiController owner)
            {
                this.owner = owner;
                timer = new Timer { Interval = 1000 }; // pokušaj na svaku 1s
                timer.Tick += Tick;
                timer.Start();
            }

            private void Tick(object sender, EventArgs e)
            {
                if (connecting) return;
                connecting = true;

                try
                {
                    // Pokušaj konekciju; ako server nije pokrenut -> SocketException
                    Communication.Instance.Connect();

                    // Uspelo -> zaustavi pokušaje i prikaži Login formu
                    timer.Stop();

                    if (owner.frmLogin == null || owner.frmLogin.IsDisposed)
                    {
                        owner.frmLogin = new FrmLogin();
                        owner.frmLogin.AutoSize = true;
                        // kada se login zatvori, zatvaramo i message loop
                        owner.frmLogin.FormClosed += (_, __) => ExitThread();
                    }

                    owner.frmLogin.Show();
                }
                catch (SocketException)
                {
                    // server još nije startovan — ćutimo i čekamo sledeći tick
                }
                catch
                {
                    // bilo koja druga greška — ignoriši i pokušaj opet
                }
                finally
                {
                    connecting = false;
                }
            }
        }

        // >>> Pozovi ovu metodu umesto dosadašnje (nema MessageBox-a, nema ranog prikaza forme)
        internal void ShowFrmLogin()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AwaitServerContext(this)); // drži app živom dok ne uspe konekcija
        }

        public void Login(object sender, EventArgs e)
        {
            if (frmLogin == null || frmLogin.IsDisposed) return;

            if (!frmLogin.Validacija())
            {
                MessageBox.Show("Molimo popunite sva polja.");
                return;
            }

            Z = new Zaposleni
            {
                Username = frmLogin.TxtUsername.Text,
                Password = frmLogin.TxtPassword.Text,
            };

            var response = Communication.Instance.Login(Z);
            if (response.ExceptionMessage == null)
            {
                frmLogin.Visible = false;
                Z = (Zaposleni)response.Result;
                MainCoordinator.Instance.ShowFrmMain();
            }
            else
            {
                MessageBox.Show(">>>" + response.ExceptionMessage);
            }
        }
    }
}
