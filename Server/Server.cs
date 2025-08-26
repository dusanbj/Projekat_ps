using Domen;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {

        Socket socket;
        private List<ClientHandler> handlers = new List<ClientHandler>();
        private bool kraj;

        public Server()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Start()
        {
            // IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ConfigurationManager.AppSettings["ip"]), int.Parse(ConfigurationManager.AppSettings["port"]));

            socket.Bind(endPoint);
            socket.Listen(5);

            Thread thread = new Thread(AcceptClient);
            thread.Start();

        }

        public void AcceptClient()
        {
            try
            {
                kraj = false;
                while (!kraj)
                {
                    Socket klijentskiSoket = socket.Accept();
                    ClientHandler handler = new ClientHandler(klijentskiSoket, handlers);
                    Thread klijentskaNit = new Thread(handler.HandleRequest);
                    klijentskaNit.Start();
                    handlers.Add(handler);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        //za sada nema primenu
        //ovo je ako budem kasnije hteo da implementiram da server moze da izloguje zaposlenog
        internal void Logout(Zaposleni zaposleni)
        {
            foreach (ClientHandler ch in handlers)
            {
                if (ch.PrijaveljniZaposleni.Username.Equals(zaposleni.Username)
                    && ch.PrijaveljniZaposleni.Password.Equals(zaposleni.Password))
                {
                    ch.Logout();
                    break;
                }
            }
        }


        public void Stop()
        {
            //zaustaviti sve ch
            for (int i = 0; i < handlers.Count; i++)
            {
                handlers[i].Logout(); //bilo je handlers[i].Logout(); => verovatno greska
            }
            handlers = new List<ClientHandler>();

            //zaustaviti Accept() metodu - osluskivanje 
            socket.Close();
            kraj = true;
        }

    }
}
