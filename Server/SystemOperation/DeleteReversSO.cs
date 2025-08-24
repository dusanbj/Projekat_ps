using Domen;
using System.Linq;

namespace Server.SystemOperation
{
    public class DeleteReversSO : SystemOperationBase
    {
        private readonly Revers input;

        public DeleteReversSO(Revers revers)
        {
            this.input = revers;
        }

        protected override void ExecuteConcreteOperation()
        {
            if (input == null)
                throw new System.Exception("Revers nije prosleđen.");
            if (input.Id <= 0)
                throw new System.Exception("Nevalidan Revers.Id.");

            // 1) Obriši stavke
            var stavke = broker.GetByCondition(new StavkaReversa(), $"idRevers = {input.Id}")
                               .Cast<StavkaReversa>()
                               .ToList();
            foreach (var s in stavke)
                broker.Delete(s);

            // 2) Obriši header
            broker.Delete(new Revers { Id = input.Id });
        }
    }
}
