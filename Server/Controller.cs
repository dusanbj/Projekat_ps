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

        public Zaposleni Login(Zaposleni argument)
        {
            LoginSO so = new LoginSO(argument);
            so.ExecuteTemplate();
            return so.Result;

        }
        internal void CreateZaposleni(Zaposleni argument)
        {
            CreateZaposleniSO so = new CreateZaposleniSO(argument);
            so.ExecuteTemplate();
        }
        internal void UpdateZaposleni (Zaposleni argument)
        {
            UpdateZaposleni so = new UpdateZaposleni(argument);
            so.ExecuteTemplate();
        }
        internal void DeleteZaposleni(Zaposleni argument)
        {
            //poziva SO
        }
        internal List<Zaposleni> GetZaposleni(String argument)
        {
            //poziva SO
            return null;
        }

        internal void CreateKlijent(Klijent argument)
        {
            CreateKlijentSO createKlijent = new CreateKlijentSO(argument);
            createKlijent.ExecuteTemplate();
        }
        internal void CreateRevers(Revers revers)
        {
            //poziva SO
        }

        internal void UpdateRevers(Revers argument)
        {
            //poziva SO
        }

        internal void DeleteRevers(Revers argument)
        {
            //poziva SO
        }
        internal void GetRevers(string argument)
        {
            //poziva SO
        }
        internal List<Klijent> GetKlijent(string argument)
        {
            //poziva SO
            return null;
        }
        internal void UpdateKlijent(Klijent argument)
        {
            //poziva SO
        }
        internal void DeleteKlijent(Klijent argument)
        {
            //poziva SO
        }
        internal List<Klijent> GetAllKlijent()
        {
            try
            {
                //broker.OpenConnection();
                //return broker.GetAll(new Klijent()).Cast<Klijent>().ToList();
                GetAllKlijentFullSO getKlijent = new GetAllKlijentFullSO();
                getKlijent.ExecuteTemplate();
                return getKlijent.Result;
            }
            finally
            {
                broker.CloseConnection();

            }
        }
        internal void CreateRoba(Roba argument)
        {
            //poziva SO
        }
        internal void UpdateRoba(Roba argument)
        {
            //poziva SO
        }
        internal void DeleteRoba(Roba argument)
        {
            //poziva SO
        }
        internal List<Roba> GetRoba(string argument)
        {
            //poziva SO
            return null;
        }
        internal void CreateMesto(Mesto argument)
        {
            //poziva SO
        }
        internal void UpdateMesto(Mesto argument)
        {
            //poziva SO
        }
        internal void DeleteMesto(Mesto argument)
        {
            //poziva SO
        }
        internal List<Mesto> GetMesto(string argument)
        {
            //poziva SO
            return null;
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
        internal void AddStrSprema(StrSprema argument)
        {
            //poziva SO
        }
        internal void UpdateStrSprema(StrSprema argument)
        {
            //poziva SO
        }
        internal void DeleteStrSprema(StrSprema argument)
        {
            //poziva SO
        }
        internal StrSprema GetStrSprema(string argument)
        {
            //pzoiva SO
            return null;
        }
    }
}
