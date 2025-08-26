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
        var req = (Request)serializer.Receive<Request>();
        var resp = ProcessRequest(req);
        serializer.Send(resp);
    }
}

        private Response ProcessRequest(Request req)
        {
            var r = new Response();
            try
            {
                switch (req.Operation)
                {
                    case Operation.Login:
                        r.Result = Controller.Instance.Login(serializer.ReadType<Zaposleni>(req.Argument));
                        break;
                    case Operation.Logout:
                           
                        break;
                    case Operation.CreateKlijent:
                        Controller.Instance.CreateKlijent(serializer.ReadType<Klijent>(req.Argument));
                        r.Result = true;
                        break;

                    case Operation.UpdateKlijent:
                        r.Result = Controller.Instance.UpdateKlijent(serializer.ReadType<Klijent>(req.Argument));
                        break;

                    case Operation.DeleteKlijent:
                        r.Result = Controller.Instance.DeleteKlijent(serializer.ReadType<Klijent>(req.Argument));
                        break;

                    case Operation.GetAllKlijent:
                        r.Result = Controller.Instance.GetAllKlijent();
                        break;

                    case Operation.GetAllMesto:
                        r.Result = Controller.Instance.GetAllMesto();
                        break;

                    case Operation.CreateRevers:
                        r.Result = Controller.Instance.CreateRevers(serializer.ReadType<Revers>(req.Argument));
                        break;

                    case Operation.UpdateRevers:
                        r.Result = Controller.Instance.UpdateRevers(serializer.ReadType<Revers>(req.Argument));
                        break;

                    case Operation.DeleteRevers:
                        r.Result = Controller.Instance.DeleteRevers(serializer.ReadType<Revers>(req.Argument));
                        break;

                    case Operation.GetRoba:
                        r.Result = Controller.Instance.GetRoba(serializer.ReadType<string>(req.Argument));
                        break;

                    case Operation.CreateRoba:
                        r.Result = Controller.Instance.CreateRoba(serializer.ReadType<Roba>(req.Argument));
                        break;

                    case Operation.UpdateRoba:
                        r.Result = Controller.Instance.UpdateRoba(serializer.ReadType<Roba>(req.Argument));
                        break;

                    case Operation.DeleteRoba:
                        r.Result = Controller.Instance.DeleteRoba(serializer.ReadType<Roba>(req.Argument));
                        break;

                    case Operation.CreateMesto:
                        r.Result = Controller.Instance.CreateMesto(serializer.ReadType<Mesto>(req.Argument));
                        break;

                    case Operation.UpdateMesto:
                        Controller.Instance.UpdateMesto(serializer.ReadType<Mesto>(req.Argument));
                        r.Result = true;
                        break;

                    case Operation.DeleteMesto:
                        Controller.Instance.DeleteMesto(serializer.ReadType<Mesto>(req.Argument));
                        r.Result = true;
                        break;

                    default:
                        r.ExceptionMessage = $"Nepodržana operacija: {req.Operation}";
                        break;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                r.ExceptionMessage = ex.Message;
            }
            return r;
        }
    }
}
