
using Common;
using Common.Communication;
using Common.Domain;
using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Communication
    {

        private static Communication _instance;
        public static Communication Instance { 
            get 
            {
                if( _instance == null ) _instance = new Communication();
                return _instance;
            } 
        }
        private Communication()
        {
            
        }

        private Socket socket;
       private JsonNetworkSerializer serializer;

        public void Connect()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("127.0.0.1", 9999);
            serializer = new JsonNetworkSerializer(socket);

        }

        internal Response Login(Zaposleni zap)
        {
            Request request = new Request
            {
                Argument = zap,
                Operation = Operation.Login
            };
            serializer.Send(request);
            Response response = serializer.Receive<Response>();

            if (response.ExceptionMessage != null)
            {
                throw new Exception(response.ExceptionMessage);
            }

            response.Result = serializer.ReadType<Zaposleni>(response.Result); // deserijalizujemo result u user-a
            return response;
        }

        internal Response CreateKlijent(Klijent klijent)
        {
            Request request = new Request
            {
                Argument = klijent,
                Operation = Operation.CreateKlijent
            };
            serializer.Send(request);

            Response response = serializer.Receive<Response>();
            if (response.ExceptionMessage != null)
            {
                throw new Exception(response.ExceptionMessage);
            }
            return response;
        }

        internal Response UpdateKlijent(Klijent klijent)
        {
            var request = new Request
            {
                Argument = klijent,
                Operation = Operation.UpdateKlijent
            };
            serializer.Send(request);

            var response = serializer.Receive<Response>();
            if (response.ExceptionMessage != null)
                throw new Exception(response.ExceptionMessage);

            return response;
        }

        internal Response DeleteKlijent(Klijent klijent)
        {
            var request = new Request
            {
                Argument = klijent,
                Operation = Operation.DeleteKlijent
            };
            serializer.Send(request);

            var response = serializer.Receive<Response>();
            if (response.ExceptionMessage != null)
                throw new Exception(response.ExceptionMessage);

            return response;
        }


        internal Response CreateRevers(Revers revers)
        {
            var request = new Request
            {
                Argument = revers,
                Operation = Operation.CreateRevers
            };
            serializer.Send(request);

            var response = serializer.Receive<Response>();
            if (response.ExceptionMessage != null)
                throw new Exception(response.ExceptionMessage);

            response.Result = serializer.ReadType<Revers>(response.Result);

            return response;
        }

        internal List<Mesto> GetAllMesto()
        {
            Request request = new Request
            {
                Operation = Operation.GetAllMesto
            };
            serializer.Send(request);
            Response response = serializer.Receive<Response>();
            return serializer.ReadType<List<Mesto>>(response.Result);

        }

        internal List<Klijent> GetAllKlijent()
        {
            Request request = new Request
            {
                Operation = Operation.GetAllKlijent
            };
            serializer.Send(request);
            Response response = serializer.Receive<Response>();
            return serializer.ReadType<List<Klijent>>(response.Result);

        }

        internal Response DeleteRevers(Revers revers)
        {
            Request request = new Request
            {
                Argument = revers,
                Operation = Operation.DeleteRevers
            };
            serializer.Send(request);

            Response response = serializer.Receive<Response>();
            if (response.ExceptionMessage != null)
            {
                throw new Exception(response.ExceptionMessage);
            }
            return response;
        }

        internal Response UpdateRevers(Revers revers)
        {
            Request request = new Request
            {
                Argument = revers,
                Operation = Operation.UpdateRevers
            };
            serializer.Send(request);

            Response response = serializer.Receive<Response>();
            if (response.ExceptionMessage != null)
            {
                throw new Exception(response.ExceptionMessage);
            }
            return response;
        }

        internal Response CreateRoba(Roba roba)
        {
            var request = new Request
            {
                Argument = roba,
                Operation = Operation.CreateRoba
            };
            serializer.Send(request);

            var response = serializer.Receive<Response>();
            if (response.ExceptionMessage != null)
                throw new Exception(response.ExceptionMessage);

            return response;
        }

        internal Response UpdateRoba(Roba roba)
        {
            var request = new Request
            {
                Argument = roba,
                Operation = Operation.UpdateRoba
            };
            serializer.Send(request);

            var response = serializer.Receive<Response>();
            if (response.ExceptionMessage != null)
                throw new Exception(response.ExceptionMessage);

            return response;
        }

        internal Response DeleteRoba(Roba roba)
        {
            var request = new Request
            {
                Argument = roba,
                Operation = Operation.DeleteRoba
            };
            serializer.Send(request);

            var response = serializer.Receive<Response>();
            if (response.ExceptionMessage != null)
                throw new Exception(response.ExceptionMessage);

            return response;
        }

        //ako je filter null, vraca svu robu
        internal List<Roba> GetRoba(string filter = null)
        {
            var request = new Request
            {
                Operation = Operation.GetRoba,
                Argument = filter // server neka tretira null/"" kao "SELECT *"
            };
            serializer.Send(request);

            var response = serializer.Receive<Response>();
            if (response.ExceptionMessage != null)
                throw new Exception(response.ExceptionMessage);

            return serializer.ReadType<List<Roba>>(response.Result);
        }
        //vraca celu listu
        internal List<Roba> GetAllRoba()
        {
            return GetRoba(null);
        }

        public Mesto CreateMesto(Mesto mesto)
        {
            var req = new Request { Operation = Operation.CreateMesto, Argument = mesto };
            serializer.Send(req);
            var resp = serializer.Receive<Response>();
            if (resp.ExceptionMessage != null) throw new Exception(resp.ExceptionMessage);
            return serializer.ReadType<Mesto>(resp.Result);
        }

        public void UpdateMesto(Mesto mesto)
        {
            var req = new Request { Operation = Operation.UpdateMesto, Argument = mesto };
            serializer.Send(req);
            var resp = serializer.Receive<Response>();
            if (resp.ExceptionMessage != null) throw new Exception(resp.ExceptionMessage);
        }

        public void DeleteMesto(Mesto mesto)
        {
            var req = new Request { Operation = Operation.DeleteMesto, Argument = mesto };
            serializer.Send(req);
            var resp = serializer.Receive<Response>();
            if (resp.ExceptionMessage != null) throw new Exception(resp.ExceptionMessage);
        }

        public Response CreateStrSprema(StrSprema ss)
        {
            var req = new Request
            {
                Operation = Operation.CreateStrSprema,
                Argument = ss
            };

            serializer.Send(req);

            var resp = serializer.Receive<Response>();
            if (resp == null)
                return new Response { ExceptionMessage = "Veza sa serverom je prekinuta." };

            // ako server vraća kreirani entitet, možeš ga tipizovati ovako:
            // resp.Result = serializer.ReadType<StrSprema>(resp.Result);

            if (resp.ExceptionMessage != null)
                throw new Exception(resp.ExceptionMessage);

            return resp;
        }

        internal void Logout()
        {
            // Ako nismo povezani, nema posla
            if (socket == null || serializer == null)
                return;

            try
            {
                // Pošalji serveru da zna da prekine sesiju (bez čekanja odgovora)
                var req = new Request
                {
                    Operation = Operation.Logout,
                    Argument = null
                };
                serializer.Send(req); // fire-and-forget
            }
            catch
            {
                // Ignorišemo greške pri slanju tokom odjave (npr. konekcija već prekinuta)
            }
            finally
            {
                try { socket.Shutdown(SocketShutdown.Both); } catch { }
                try { socket.Close(); } catch { }
                socket = null;
                serializer = null;
            }
        }

        internal List<Klijent> GetKlijent(string filter = null)
        {
            var request = new Request
            {
                Operation = Operation.GetKlijent, // dodaćemo na serverskoj strani
                Argument = filter                // null ili "" = vrati sve (dogovor)
            };

            serializer.Send(request);

            var response = serializer.Receive<Response>();
            if (response.ExceptionMessage != null)
                throw new Exception(response.ExceptionMessage);

            return serializer.ReadType<List<Klijent>>(response.Result);
        }
    }
}
