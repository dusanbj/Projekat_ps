using Domen;
using System.Linq;

namespace Server.SystemOperation
{
    public class CreateMestoSO : SystemOperationBase
    {
        private readonly Mesto _mesto;
        public CreateMestoSO(Mesto mesto) { _mesto = mesto; }

        protected override void ExecuteConcreteOperation()
        {
            // 1) PTT mora biti jedinstven
            var postojePtt = broker.GetByCondition(new Mesto(), $"ptt = {_mesto.Ptt}")
                                   .Cast<Mesto>().Any();
            if (postojePtt)
                throw new System.Exception("Mesto sa datim PTT već postoji.");

            // 2) Naziv takođe držimo jedinstven (case-insensitive)
            var safeNaziv = (_mesto.Naziv ?? string.Empty).Replace("'", "''");
            var postojeNaziv = broker
                .GetByCondition(new Mesto(), $"LOWER(naziv) = LOWER('{safeNaziv}')")
                .Cast<Mesto>().Any();
            if (postojeNaziv)
                throw new System.Exception("Mesto sa datim nazivom već postoji.");

            broker.Add(_mesto);
        }
    }
}
