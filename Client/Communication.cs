
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
            Request req = new Request
            {
                Argument = zap,
                Operation = Operation.Login
            };
            serializer.Send(req);
            Response response = serializer.Receive<Response>();

            //if (response.ExceptionMessage != null)
            //{
            //    throw new Exception(response.ExceptionMessage);
            //}

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

        internal Response CreateRevers(Revers revers)
        {
            Request request = new Request
            {
                Argument = revers,
                Operation = Operation.CreateRevers
            };
            serializer.Send(request);

            Response response = serializer.Receive<Response>();
            if (response.ExceptionMessage != null)
            {
                throw new Exception(response.ExceptionMessage);
            }
            return response;
        }

        internal List<Mesto> GetAllCity()
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

        //internal List<Mesto> GetAllCity()
        //{
        //    Request request = new Request
        //    {
        //        Operation = Operation.GetAllMesto
        //    };
        //    serializer.Send(request);
        //    Response response = serializer.Receive<Response>();
        //    return serializer.ReadType<List<Mesto>>(response.Result);

        //}
    }
}
