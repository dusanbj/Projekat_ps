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
            //prepraviti da vraca Zaposleni
        }
        internal void UpdateZaposleni (Zaposleni argument)
        {
            UpdateZaposleni so = new UpdateZaposleni(argument);
            so.ExecuteTemplate();
            //prepraviti da vraca bool
        }
        internal void DeleteZaposleni(Zaposleni argument)
        {
            DeleteZaposleniSO so = new DeleteZaposleniSO(argument);
            so.ExecuteTemplate();
            //kako da napravim da bude bool nzm
        }
        internal List<Zaposleni> GetZaposleni(String argument)
        {
            //poziva SO
            return null;
        }

        internal void CreateKlijent(Klijent argument)
        {
            //ispraviti da vraca klijenta
            CreateKlijentSO createKlijent = new CreateKlijentSO(argument);
            createKlijent.ExecuteTemplate();
        }
        internal Revers CreateRevers(Revers revers)
        {
            //poziva SO
            return null;
            //vraca revers sa ID-em
        }

        internal bool UpdateRevers(Revers argument)
        {
            //poziva SO
            return false;
        }

        internal bool DeleteRevers(Revers argument)
        {
            //poziva SO
            return false;
        }
        internal Revers GetRevers(string argument)
        {
            return null;
            //poziva SO
        }
        internal List<Revers> GetAllRevers()
        {
            //poziva SO
            return null;
        }
        internal List<Klijent> GetKlijent(string argument)
        {
            //poziva SO
            return null;
        }
        internal bool UpdateKlijent(Klijent argument)
        {
            //poziva SO
            return false;
        }
        internal bool DeleteKlijent(Klijent argument)
        {
            //poziva SO
            return false;
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
        internal Roba CreateRoba(Roba argument)
        {
            var so = new CreateRobaSO(argument);
            so.ExecuteTemplate();
            return argument; // mozda da vratimo ID posle INSERT-a -> treba dopuniti
        }
        internal bool UpdateRoba(Roba argument)
        {
            var so = new UpdateRobaSO(argument);
            so.ExecuteTemplate();
            return true;
        }
        internal bool DeleteRoba(Roba argument)
        {
            var so = new DeleteRobaSO(argument);
            so.ExecuteTemplate();
            return true;
        }
        internal List<Roba> GetRoba(string argument) // null ili "" => sve
        {
            var so = new GetRobaSO(argument);
            so.ExecuteTemplate();
            return so.Result;
        }
        internal Mesto CreateMesto(Mesto argument)
        {
            //poziva SO
            return null;
        }
        internal bool UpdateMesto(Mesto argument)
        {
            //poziva SO
            return false;
        }
        internal bool DeleteMesto(Mesto argument)
        {
            //poziva SO
            return false;
        }
        internal List<Mesto> GetMesto(string argument)
        {
            //poziva SO
            return null;
        }
        internal List<Mesto> GetAllMesto()
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
        internal bool UpdateStrSprema(StrSprema argument)
        {
            //poziva SO
            return false;
        }
        internal bool DeleteStrSprema(StrSprema argument)
        {
            //poziva SO
            return false;
        }
        internal StrSprema GetStrSprema(string argument)
        {
            //pzoiva SO
            return null;
        }
    }
}
