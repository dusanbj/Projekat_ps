using Common.Communication;
using Common.Domain;
using Domen;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Security;
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
                        Controller.Instance.CreateKlijent(serializer.ReadType<Klijent>(req.Argument));
                        break;
                    case Operation.Login:
                        r.Result = Controller.Instance.Login(serializer.ReadType<Zaposleni>(req.Argument));
                        break;
                    case Operation.GetAllMesto:
                        r.Result = Controller.Instance.GetAllMesto();
                        break;
                    case Operation.GetAllKlijent:
                        r.Result = Controller.Instance.GetAllKlijent();
                        break;
                    case Operation.DeleteRevers:
                        Controller.Instance.DeleteRevers(serializer.ReadType<Revers>(req.Argument));
                        break;
                    case Operation.UpdateRevers:
                        Controller.Instance.UpdateRevers(serializer.ReadType<Revers>(req.Argument));
                        break;
                    case Operation.CreateRevers:
                        Controller.Instance.CreateRevers(serializer.ReadType<Revers>(req.Argument));
                        break;
                    case Operation.CreateRoba:
                        Controller.Instance.CreateRoba(serializer.ReadType<Roba>(req.Argument));
                        break;
                    case Operation.UpdateRoba:
                        Controller.Instance.UpdateRoba(serializer.ReadType<Roba>(req.Argument));
                        break;
                    case Operation.DeleteRoba:
                        Controller.Instance.DeleteRoba(serializer.ReadType<Roba>(req.Argument));
                        break;
                    case Operation.GetRoba:
                        r.Result = Controller.Instance.GetRoba(serializer.ReadType<string>(req.Argument)); // null => sve
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
