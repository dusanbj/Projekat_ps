using Common.Domain;
using Domen;
using System.Collections.Generic;
using System.Linq;

namespace Server.SystemOperation
{
    public class GetMestoSO : SystemOperationBase
    {
        private readonly string _filter; // može biti ptt ili deo naziva
        public List<Mesto> Result { get; private set; }

        public GetMestoSO(string filter) { _filter = filter; }

        protected override void ExecuteConcreteOperation()
        {
            if (string.IsNullOrWhiteSpace(_filter))
            {
                Result = broker.GetAll(new Mesto()).Cast<Mesto>().ToList();
                return;
            }

            // ako je broj => tretira se kao PTT
            if (long.TryParse(_filter, out var ptt))
            {
                Result = broker.GetByCondition(new Mesto(), $"ptt = {ptt}")
                               .Cast<Mesto>().ToList();
            }
            else
            {
                var safe = _filter.Replace("'", "''");
                Result = broker.GetByCondition(new Mesto(), $"naziv LIKE '%{safe}%'")
                               .Cast<Mesto>().ToList();
            }
        }
    }
}
