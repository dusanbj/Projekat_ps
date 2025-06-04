using Common.Communication;
using Common.Domain;
using Domen;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ClientHandler
    {
        private JsonNetworkSerializer serializer;
        private Socket socket;

        public ClientHandler(Socket socket)
        {
            this.socket = socket;
            serializer = new JsonNetworkSerializer(socket);
        }

        public void HandleRequest()
        {
            while (true)
            {
                Request req = (Request)serializer.Receive<Request>();
                Response r = ProcessRequest(req);
                serializer.Send(r);
            }
        }

        private Response ProcessRequest(Request req)
        {
            Response r = new Response();
            try
            {
                switch (req.Operation)
                {
                    case Operation.CreateKlijent:
                        Controller.Instance.AddPerson(serializer.ReadType<Klijent>(req.Argument));
                        break;
                    case Operation.Login:
                        r.Result = Controller.Instance.Login(serializer.ReadType<Zaposleni>(req.Argument));
                        break;
                    case Operation.GetAllMesto:
                        r.Result = Controller.Instance.GetAllCity();
                        break;
                    case Operation.GetAllKlijent:
                        r.Result = Controller.Instance.GetAllKlijent();
                        break;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(r.ExceptionMessage);
                r.ExceptionMessage = ex.Message;
            }
            return r;
        }
    }
}
