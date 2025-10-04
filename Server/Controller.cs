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
            SystemOperationBase so = new LoginSO(argument);
            so.ExecuteTemplate();
            if (so != null)
            {
                prijavljeniZaposleni.Add(argument);
            }
            return ((LoginSO)so).Result;
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
        internal Zaposleni CreateZaposleni(Zaposleni argument)
        {
            SystemOperationBase so = new CreateZaposleniSO(argument);
            so.ExecuteTemplate();
            return argument;
        }

        internal void UpdateZaposleni(Zaposleni argument)
        {
            SystemOperationBase so = new UpdateZaposleniSO(argument);
            so.ExecuteTemplate();
        }

        internal void DeleteZaposleni(Zaposleni argument)
        {
            SystemOperationBase so = new DeleteZaposleniSO(argument);
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
            SystemOperationBase so = new GetAllZaposleniSO();
            so.ExecuteTemplate();
            return ((GetAllZaposleniSO)so).Result;
        }

        // ===========================
        //           KLIJENT
        // ===========================
        internal Klijent CreateKlijent(Klijent argument)
        {
            SystemOperationBase so = new CreateKlijentSO(argument);
            so.ExecuteTemplate();
            return argument;
        }

        internal List<Klijent> GetKlijent(string argument)
        {
            if (string.IsNullOrWhiteSpace(argument))
            {
                return GetAllKlijent();
            }

            SystemOperationBase so = new GetKlijentSO(argument.Trim());
            so.ExecuteTemplate();
            return ((GetKlijentSO)so).Result;
        }

        internal bool UpdateKlijent(Klijent argument)
        {
            SystemOperationBase so = new UpdateKlijentSO(argument);
            so.ExecuteTemplate();
            return true;
        }

        internal bool DeleteKlijent(Klijent argument)
        {
            SystemOperationBase so = new DeleteKlijentSO(argument);
            so.ExecuteTemplate();
            return true;
        }

        internal List<Klijent> GetAllKlijent()
        {
            try
            {
                SystemOperationBase so = new GetAllKlijentFullSO();
                so.ExecuteTemplate();
                return ((GetAllKlijentFullSO)so).Result;
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
            SystemOperationBase so = new CreateRobaSO(argument);
            so.ExecuteTemplate();
            return argument;
        }

        internal bool UpdateRoba(Roba argument)
        {
            SystemOperationBase so = new UpdateRobaSO(argument);
            so.ExecuteTemplate();
            return true;
        }

        internal bool DeleteRoba(Roba argument)
        {
            SystemOperationBase so = new DeleteRobaSO(argument);
            so.ExecuteTemplate();
            return true;
        }

        internal List<Roba> GetRoba(string argument) // null ili "" => sve
        {
            SystemOperationBase so = new GetRobaSO(argument);
            so.ExecuteTemplate();
            return ((GetRobaSO)so).Result;
        }

        // ===========================
        //            MESTO
        // ===========================
        internal Mesto CreateMesto(Mesto argument)
        {
            SystemOperationBase so = new CreateMestoSO(argument);
            so.ExecuteTemplate();
            return argument;
        }

        internal bool UpdateMesto(Mesto argument)
        {
            SystemOperationBase so = new UpdateMestoSO(argument);
            so.ExecuteTemplate();
            return true;
        }

        internal bool DeleteMesto(Mesto argument)
        {
            SystemOperationBase so = new DeleteMestoSO(argument);
            so.ExecuteTemplate();
            return true;
        }

        internal List<Mesto> GetAllMesto()
        {
            SystemOperationBase so = new GetAllMestoSO();
            so.ExecuteTemplate();
            return ((GetAllMestoSO)so).Result;
        }

        internal List<Mesto> GetMesto(string filter)
        {
            SystemOperationBase so = new GetMestoSO(filter);
            so.ExecuteTemplate();
            return ((GetMestoSO)so).Result;
        }

        // ===========================
        //        STRUČNA SPREMA
        // ===========================
        internal StrSprema AddStrSprema(StrSprema argument)
        {
            SystemOperationBase so = new AddStrSpremaSO(argument);
            so.ExecuteTemplate();
            return argument;
        }

        // ===========================
        //            REVERS
        // ===========================
        internal Revers CreateRevers(Revers revers)
        {
            SystemOperationBase so = new CreateReversSO(revers);
            so.ExecuteTemplate();
            return ((CreateReversSO)so).Result; // revers sa ID-em
        }

        internal bool UpdateRevers(Revers argument)
        {
            SystemOperationBase so = new UpdateReversSO(argument);
            so.ExecuteTemplate();
            return true;
        }

        internal bool DeleteRevers(Revers argument)
        {
            SystemOperationBase so = new DeleteReversSO(argument);
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
            SystemOperationBase so = new GetReversSO(argument); // SO koji sklapa WHERE uslov
            so.ExecuteTemplate();
            return ((GetReversSO)so).Result; // List<Revers>
        }

        internal List<Revers> GetAllRevers()
        {
            SystemOperationBase so = new GetAllReversSO();
            so.ExecuteTemplate();
            return ((GetAllReversSO)so).Result;
        }

        internal List<StavkaReversa> GetStavkeByRevers(long idRevers)
        {
            SystemOperationBase so = new GetReversSO(idRevers.ToString());
            so.ExecuteTemplate();

            // Treba da postoji tačno jedan revers sa tim ID-jem
            var revers = ((GetReversSO)so).Result.FirstOrDefault(r => r.Id == idRevers);

            return revers?.Stavke ?? new List<StavkaReversa>();
        }
    }
}
