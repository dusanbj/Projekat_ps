using Domen;
using System.Linq;

namespace Server.SystemOperation
{
    public class UpdateRobaSO : SystemOperationBase
    {
        private readonly Roba roba;
        public UpdateRobaSO(Roba roba) { this.roba = roba; }

        protected override void ExecuteConcreteOperation()
        {
            // Validacija
            var naziv = (roba.Naziv ?? string.Empty).Trim();
            if (string.IsNullOrEmpty(naziv))
                throw new System.Exception("Naziv ne sme biti prazan.");

            if (roba.Cena < 0)
                throw new System.Exception("Cena ne može biti negativna.");

            // Duplikati po nazivu (case-insensitive), isključi trenutni ID
            var safeNaziv = naziv.Replace("'", "''");
            var postojiDrugiSaIstimNazivom = broker
                .GetByCondition(new Roba(), $"LOWER(naziv) = LOWER('{safeNaziv}') AND id <> {roba.Id}")
                .Cast<Roba>()
                .Any();

            if (postojiDrugiSaIstimNazivom)
                throw new System.Exception("Roba sa datim nazivom već postoji.");

            // Update
            broker.Update(roba);
        }
    }
}
