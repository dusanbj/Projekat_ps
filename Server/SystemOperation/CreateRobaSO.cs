using Domen;
using System.Linq;

namespace Server.SystemOperation
{
    public class CreateRobaSO : SystemOperationBase
    {
        private readonly Roba roba;
        public CreateRobaSO(Roba roba) { this.roba = roba; }

        protected override void ExecuteConcreteOperation()
        {
            // Validacija
            var naziv = (roba.Naziv ?? string.Empty).Trim();
            if (string.IsNullOrEmpty(naziv))
                throw new System.Exception("Naziv ne sme biti prazan.");

            if (roba.Cena < 0)
                throw new System.Exception("Cena ne može biti negativna.");

            // Duplikati po nazivu (case-insensitive)
            var safeNaziv = naziv.Replace("'", "''");
            var postoji = broker
                .GetByCondition(new Roba(), $"LOWER(naziv) = LOWER('{safeNaziv}')")
                .Cast<Roba>()
                .Any();

            if (postoji)
                throw new System.Exception("Roba sa datim nazivom već postoji.");

            // Upis
            broker.Add(roba);
        }
    }
}
