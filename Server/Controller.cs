using Common;
using Common.Domain;
using DBBroker;
using Domen;
using Server.SystemOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Controller
    {
        private Broker broker;

        private static Controller instance;
        public static Controller Instance
        {
            get
            {
                if(instance == null) instance = new Controller();
                return instance;
            }
        }
        private Controller() { broker = new Broker(); }

        public Zaposleni Login(Zaposleni zap)
        {
            LoginSO so = new LoginSO(zap);
            so.ExecuteTemplate();
            return so.Result;

        }

        internal void AddPerson(Klijent argument)
        {
            AddKlijentSO addPerson = new AddKlijentSO(argument);
            addPerson.ExecuteTemplate();
        }

        internal List<Mesto> GetAllCity()
        {
            try
            {
                broker.OpenConnection();
                return broker.GetAll(new Mesto()).Cast<Mesto>().ToList();
            }
            finally
            {
                broker.CloseConnection();

            }
        }

        internal List<Klijent> GetAllKlijent()
        {
            try
            {
                broker.OpenConnection();
                return broker.GetAll(new Klijent()).Cast<Klijent>().ToList();
            }
            finally
            {
                broker.CloseConnection();

            }
        }
    }
}
