using Common;
using Common.Domain;
using DBBroker;
using Domen;
using Server.SystemOperation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Server
{
    public class Controller
    {
        private Broker broker;

        private static Controller instance;
        private List<Zaposleni> prijavljeniZaposleni = new List<Zaposleni>();
        public static Controller Instance
        {
            get
            {
                if (instance == null) instance = new Controller();
                return instance;
            }
        }
        private Controller() { broker = new Broker(); }

        // ===========================
        //          LOGIN
        // ===========================
        public Zaposleni Login(Zaposleni argument)
        {
            var so = new LoginSO(argument);
            so.ExecuteTemplate();
            if (so != null)
            {
                prijavljeniZaposleni.Add(argument);
            }
            return so.Result;
        }

        internal void Logout(Zaposleni prijavljen)
        {
            foreach (Zaposleni z in prijavljeniZaposleni)
            {
                if (z.Username.Equals(prijavljen.Username)
                    && z.Password.Equals(prijavljen.Password))
                {
                    prijavljeniZaposleni.Remove(z);
                    break;
                }
            }
        }

        // ===========================
        //        ZAPOSLENI
        // ===========================
        internal void CreateZaposleni(Zaposleni argument)
        {
            var so = new CreateZaposleniSO(argument);
            so.ExecuteTemplate();
            // TODO: vratiti kreiranog zaposlenog ako je potrebno
        }

        internal void UpdateZaposleni(Zaposleni argument)
        {
            var so = new UpdateZaposleni(argument);
            so.ExecuteTemplate();
        }

        internal void DeleteZaposleni(Zaposleni argument)
        {
            var so = new DeleteZaposleniSO(argument);
            so.ExecuteTemplate();
        }

        // (opciono) filtrirana pretraga zaposlenih – trenutno nije korišćeno
        internal List<Zaposleni> GetZaposleni(string argument)
        {
            // Dodati SO po potrebi (npr. GetZaposleniSO)
            return new List<Zaposleni>();
        }

        internal List<Zaposleni> GetAllZaposleni()
        {
            var so = new GetAllZaposleniSO();
            so.ExecuteTemplate();
            return so.Result;
        }

        // ===========================
        //           KLIJENT
        // ===========================
        internal void CreateKlijent(Klijent argument)
        {
            var so = new CreateKlijentSO(argument);
            so.ExecuteTemplate();
        }

        internal List<Klijent> GetKlijent(string argument)
        {
            if (string.IsNullOrWhiteSpace(argument))
            {
                return GetAllKlijent();
            }

            var so = new GetKlijentSO(argument.Trim());
            so.ExecuteTemplate();
            return so.Result;
        }

        internal bool UpdateKlijent(Klijent argument)
        {
            var so = new UpdateKlijentSO(argument);
            so.ExecuteTemplate();
            return true;
        }

        internal bool DeleteKlijent(Klijent argument)
        {
            var so = new DeleteKlijentSO(argument);
            so.ExecuteTemplate();
            return true;
        }

        internal List<Klijent> GetAllKlijent()
        {
            try
            {
                var so = new GetAllKlijentFullSO();
                so.ExecuteTemplate();
                return so.Result;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        // ===========================
        //            ROBA
        // ===========================
        internal Roba CreateRoba(Roba argument)
        {
            var so = new CreateRobaSO(argument);
            so.ExecuteTemplate();
            return argument;
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

        // ===========================
        //            MESTO
        // ===========================
        internal Mesto CreateMesto(Mesto argument)
        {
            var so = new CreateMestoSO(argument);
            so.ExecuteTemplate();
            return argument;
        }

        internal bool UpdateMesto(Mesto argument)
        {
            var so = new UpdateMestoSO(argument);
            so.ExecuteTemplate();
            return true;
        }

        internal bool DeleteMesto(Mesto argument)
        {
            var so = new DeleteMestoSO(argument);
            so.ExecuteTemplate();
            return true;
        }

        internal List<Mesto> GetAllMesto()
        {
            var so = new GetAllMestoSO();
            so.ExecuteTemplate();
            return so.Result;
        }

        internal List<Mesto> GetMesto(string filter)
        {
            var so = new GetMestoSO(filter);
            so.ExecuteTemplate();
            return so.Result;
        }

        // ===========================
        //        STRUČNA SPREMA
        // ===========================
        internal StrSprema AddStrSprema(StrSprema argument)
        {
            var so = new CreateStrSpremaSO(argument);
            so.ExecuteTemplate();
            return argument;
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
            //poziva SO
            return null;
        }

        // ===========================
        //            REVERS
        // ===========================
        internal Revers CreateRevers(Revers revers)
        {
            var so = new CreateReversSO(revers);
            so.ExecuteTemplate();
            return so.Result; // revers sa ID-em
        }

        internal bool UpdateRevers(Revers argument)
        {
            var so = new UpdateReversSO(argument);
            so.ExecuteTemplate();
            return true;
        }

        internal bool DeleteRevers(Revers argument)
        {
            var so = new DeleteReversSO(argument);
            so.ExecuteTemplate();
            return true;
        }

        // **SEARCH**: vrati listu reversa po filteru (ime/prezime zaposlenog/klijenta, id klijenta, id zaposlenog, id reversa)
        internal List<Revers> GetRevers(string argument)
        {
            if (string.IsNullOrWhiteSpace(argument))
            {
                return GetAllRevers();
            }
            var so = new GetReversSO(argument); // SO koji sklapa WHERE uslov
            so.ExecuteTemplate();
            return so.Result; // List<Revers>
        }

        internal List<Revers> GetAllRevers()
        {
            var so = new GetAllReversSO();
            so.ExecuteTemplate();
            return so.Result;
        }

        internal List<StavkaReversa> GetStavkeByRevers(long idRevers)
        {
            var so = new GetReversSO(idRevers.ToString());
            so.ExecuteTemplate();

            // Treba da postoji tačno jedan revers sa tim ID-jem
            var revers = so.Result.FirstOrDefault(r => r.Id == idRevers);

            return revers?.Stavke ?? new List<StavkaReversa>();
        }
    }
}
