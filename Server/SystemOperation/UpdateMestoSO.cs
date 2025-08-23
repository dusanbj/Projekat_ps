using Domen;
using System.Linq;

namespace Server.SystemOperation
{
    public class UpdateMestoSO : SystemOperationBase
    {
        private readonly Mesto _mesto;
        public UpdateMestoSO(Mesto mesto) { _mesto = mesto; }

        protected override void ExecuteConcreteOperation()
        {
            // PTT je PK – ne menjamo ga, ali proverimo da li naziv ulazi u konflikt sa drugim zapisom
            var safeNaziv = (_mesto.Naziv ?? string.Empty).Replace("'", "''");
            var konfliktNaziv = broker
                .GetByCondition(new Mesto(), $"LOWER(naziv) = LOWER('{safeNaziv}') AND ptt <> {_mesto.Ptt}")
                .Cast<Mesto>().Any();

            if (konfliktNaziv)
                throw new System.Exception("Već postoji drugo mesto sa tim nazivom.");

            broker.Update(_mesto);
        }
    }
}
