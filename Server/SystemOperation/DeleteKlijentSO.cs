using Domen;
using System.Linq;
// ako možeš, referenciraj Microsoft.Data.SqlClient za tačnu detekciju
// using Microsoft.Data.SqlClient;

namespace Server.SystemOperation
{
    public class DeleteKlijentSO : SystemOperationBase
    {
        private readonly Klijent p;

        public DeleteKlijentSO(Klijent p) { this.p = p; }

        protected override void ExecuteConcreteOperation()
        {
            if (p == null) throw new System.Exception("Klijent nije prosleđen.");
            if (p.Id <= 0) throw new System.Exception("Nevalidan Klijent.Id.");

            // 1) Pre-check radi lepše poruke (nije race-proof)
            var imaReversa = broker.GetByCondition(new Revers(), $"idKlijent = {p.Id}")
                                   .Cast<Revers>()
                                   .Any();
            if (imaReversa)
                throw new System.Exception("Klijent se koristi u reversima i ne može biti obrisan.");

            // 2) Stvarni delete + fallback na FK ogranicenje (proveri da li narusava FK)
            try
            {
                broker.Delete(p);
            }
            catch (System.Exception ex)
            {
                if (IsForeignKeyViolation(ex))
                    throw new System.Exception("Klijent se koristi u reversima i ne može biti obrisan.");
                // Ako nije FK problem, prosledi dalje originalnu gresku (zadrzi stack trace kao InnerException)
                throw new System.Exception(ex.Message, ex);
            }
        }

        //ne znam tacno koji exception ce da baci pa sam obuhvatio sve
        private static bool IsForeignKeyViolation(System.Exception ex)
        {
            // SQL Server (ako je dostupno): 547 = FK/CK violation
            // if (ex is SqlException sqlEx && sqlEx.Number == 547) return true;
            // if (ex.InnerException is SqlException innerSql && innerSql.Number == 547) return true;

            // Fallback: 
            var txt = ex.ToString();
            return txt.IndexOf("FOREIGN KEY", System.StringComparison.OrdinalIgnoreCase) >= 0
                || txt.IndexOf("REFERENCE constraint", System.StringComparison.OrdinalIgnoreCase) >= 0
                || txt.IndexOf("violates foreign key constraint", System.StringComparison.OrdinalIgnoreCase) >= 0
                || txt.IndexOf("constraint failed", System.StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
