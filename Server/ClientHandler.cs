using Common.Communication;
using Common.Domain;
using Domen;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Security;

namespace Server
{
    public class ClientHandler
    {
        private JsonNetworkSerializer serializer;
        private Socket socket;
        private bool kraj;
        private List<ClientHandler> clientHandlers;

        public Zaposleni PrijaveljniZaposleni { get; set; }

        public ClientHandler(Socket socket, List<ClientHandler> clientHandlers)
        {
            this.socket = socket;
            serializer = new JsonNetworkSerializer(socket);
            this.clientHandlers = clientHandlers;
        }

        public void HandleRequest()
        {
            kraj = false;

            try
            {
                while (!kraj)
                {
                    Request req = null;
                    try
                    {
                        req = serializer.Receive<Request>();
                    }
                    catch (IOException) { break; }
                    catch (SocketException) { break; }

                    if (req == null) break;

                    Response resp;
                    try
                    {
                        resp = ProcessRequest(req) ?? new Response();
                    }
                    catch (Exception ex)
                    {
                        resp = new Response { ExceptionMessage = ex.Message };
                    }

                    try
                    {
                        serializer.Send(resp);
                    }
                    catch (IOException) { break; }
                    catch (SocketException) { break; }
                    catch (ObjectDisposedException) { break; }
                }
            }
            finally
            {
                try { serializer?.Close(); } catch { }
                try { socket?.Close(); } catch { }
                socket = null;
            }
        }

        private Response ProcessRequest(Request req)
        {
            if (req == null) return new Response { ExceptionMessage = "Prekid veze." };

            var r = new Response();
            try
            {
                switch (req.Operation)
                {
                    case Operation.Login:
                        Zaposleni zap = serializer.ReadType<Zaposleni>(req.Argument);
                        r.Result = Controller.Instance.Login(zap);
                        if (r.Result != null) PrijaveljniZaposleni = zap;
                        break;

                    case Operation.Logout:
                        r.Result = true;
                        Logout();
                        break;

                    case Operation.CreateKlijent:
                        Controller.Instance.CreateKlijent(serializer.ReadType<Klijent>(req.Argument));
                        r.Result = true;
                        break;

                    case Operation.GetKlijent:
                        string filter = null;

                        if (req.Argument == null)
                        {
                            filter = null; // tretiramo kao "vrati sve"
                        }
                        else if (req.Argument is string s)
                        {
                            filter = s;    // za string nema potrebe za ReadType
                        }
                        else
                        {
                            // npr. JToken / boxed JSON -> deserijalizuj
                            filter = serializer.ReadType<string>(req.Argument);
                        }

                        // prazne/whitespace tretiraj kao null
                        if (string.IsNullOrWhiteSpace(filter)) filter = null;

                        r.Result = Controller.Instance.GetKlijent(filter); // List<Klijent>
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

                    case Operation.CreateStrSprema:
                        r.Result = Controller.Instance.AddStrSprema(serializer.ReadType<StrSprema>(req.Argument));
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

        public void Logout()
        {
            kraj = true;
            Controller.Instance.Logout(PrijaveljniZaposleni);
            clientHandlers.Remove(this);
            socket.Close();
            socket = null;
        }
    }
}
