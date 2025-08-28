using Common;
using Common.Communication;
using Common.Domain;
using Domen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;

namespace Client
{
    public class Communication
    {
        private static Communication _instance;
        public static Communication Instance
        {
            get
            {
                if (_instance == null) _instance = new Communication();
                return _instance;
            }
        }
        private Communication() { }

        private Socket socket;
        private JsonNetworkSerializer serializer;

        public void Connect()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("127.0.0.1", 9999);
            serializer = new JsonNetworkSerializer(socket);
        }

        // ==========
        // Helpers
        // ==========
        private void EnsureReady()
        {
            if (socket == null || serializer == null)
                throw new Exception("Niste povezani na server.");
        }

        private void CleanupConnection()
        {
            try { socket?.Shutdown(SocketShutdown.Both); } catch { }
            try { socket?.Close(); } catch { }
            socket = null;
            serializer = null;
        }

        private Response SendAndReceiveRaw(Operation op, object arg)
        {
            EnsureReady();

            try
            {
                var request = new Request { Operation = op, Argument = arg };
                serializer.Send(request);

                var response = serializer.Receive<Response>();
                if (response == null)
                    throw new Exception("Veza sa serverom je prekinuta ili server nije dostupan.");

                if (response.ExceptionMessage != null)
                    throw new Exception(response.ExceptionMessage);

                return response;
            }
            catch (SocketException)
            {
                CleanupConnection();
                throw new Exception("Server nije dostupan (SocketException). Proverite da li je pokrenut.");
            }
            catch (IOException)
            {
                CleanupConnection();
                throw new Exception("Veza sa serverom je prekinuta (IOException).");
            }
            catch
            {
                // nemoj čistiti konekciju za sve ostale greške – mogu biti biznis greške
                throw;
            }
        }

        private T SendAndReceive<T>(Operation op, object arg) where T : class
        {
            var resp = SendAndReceiveRaw(op, arg);
            return serializer.ReadType<T>(resp.Result);
        }


        // ==========
        // API
        // ==========

        internal Response Login(Zaposleni zap)
        {
            var resp = SendAndReceiveRaw(Operation.Login, zap);
            resp.Result = serializer.ReadType<Zaposleni>(resp.Result);
            return resp;
        }

        internal Response CreateKlijent(Klijent klijent)
            => SendAndReceiveRaw(Operation.CreateKlijent, klijent);

        internal Response UpdateKlijent(Klijent klijent)
            => SendAndReceiveRaw(Operation.UpdateKlijent, klijent);

        internal Response DeleteKlijent(Klijent klijent)
            => SendAndReceiveRaw(Operation.DeleteKlijent, klijent);

        internal Response CreateRevers(Revers revers)
        {
            var resp = SendAndReceiveRaw(Operation.CreateRevers, revers);
            resp.Result = serializer.ReadType<Revers>(resp.Result);
            return resp;
        }

        internal Response DeleteRevers(Revers revers)
            => SendAndReceiveRaw(Operation.DeleteRevers, revers);

        internal Response UpdateRevers(Revers revers)
            => SendAndReceiveRaw(Operation.UpdateRevers, revers);

        internal Response CreateRoba(Roba roba)
            => SendAndReceiveRaw(Operation.CreateRoba, roba);

        internal Response UpdateRoba(Roba roba)
            => SendAndReceiveRaw(Operation.UpdateRoba, roba);

        internal Response DeleteRoba(Roba roba)
            => SendAndReceiveRaw(Operation.DeleteRoba, roba);

        // null filter => sve
        internal List<Roba> GetRoba(string filter = null)
            => SendAndReceive<List<Roba>>(Operation.GetRoba, filter);

        internal List<Roba> GetAllRoba()
            => GetRoba(null);

        public Mesto CreateMesto(Mesto mesto)
            => SendAndReceive<Mesto>(Operation.CreateMesto, mesto);

        public void UpdateMesto(Mesto mesto)
            => SendAndReceiveRaw(Operation.UpdateMesto, mesto);

        public void DeleteMesto(Mesto mesto)
            => SendAndReceiveRaw(Operation.DeleteMesto, mesto);

        public Response CreateStrSprema(StrSprema ss)
        {
            var resp = SendAndReceiveRaw(Operation.CreateStrSprema, ss);
            // Ako server vraća kreirani entitet:
            // resp.Result = serializer.ReadType<StrSprema>(resp.Result);
            return resp;
        }

        internal void Logout()
        {
            if (socket == null || serializer == null) return;

            try
            {
                var req = new Request { Operation = Operation.Logout, Argument = null };
                serializer.Send(req);
            }
            catch { }
            finally
            {
                CleanupConnection();
            }
        }

        internal List<Klijent> GetKlijent(string filter = null)
            => SendAndReceive<List<Klijent>>(Operation.GetKlijent, filter);

        internal List<Mesto> GetAllMesto()
            => SendAndReceive<List<Mesto>>(Operation.GetAllMesto, null);

        internal List<Klijent> GetAllKlijent()
            => SendAndReceive<List<Klijent>>(Operation.GetAllKlijent, null);

        internal List<Revers> GetAllRevers()
            => SendAndReceive<List<Revers>>(Operation.GetAllRevers, null);

        internal List<Zaposleni> GetAllZaposleni()
            => SendAndReceive<List<Zaposleni>>(Operation.GetAllZaposleni, null);

        internal List<Revers> GetRevers(string filter)
            => SendAndReceive<List<Revers>>(Operation.GetRevers, string.IsNullOrWhiteSpace(filter) ? null : filter);

        internal List<StavkaReversa> GetStavkeByRevers(long idRevers)
            => SendAndReceive<List<StavkaReversa>>(Operation.GetStavkeByRevers, idRevers);
    }
}
