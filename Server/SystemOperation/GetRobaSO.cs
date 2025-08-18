using Common.Domain;
using Domen;
using System.Collections.Generic;
using System.Linq;

namespace Server.SystemOperation
{
    public class GetRobaSO : SystemOperationBase
    {
        private readonly string filter;
        public List<Roba> Result { get; private set; }

        public GetRobaSO(string filter)
        {
            this.filter = filter;
        }

        protected override void ExecuteConcreteOperation()
        {
            if (string.IsNullOrWhiteSpace(filter))
            {
                Result = broker.GetAll(new Roba()).Cast<Roba>().ToList();
                return;
            }

            // Ako je broj -> traži po ID, inače po nazivu (LIKE)
            if (long.TryParse(filter, out var id))
            {
                var list = broker.GetByCondition(new Roba(), $"id = {id}");
                Result = list.Cast<Roba>().ToList();
            }
            else
            {
                var safe = filter.Replace("'", "''");
                var list = broker.GetByCondition(new Roba(), $"naziv LIKE '%{safe}%'");
                Result = list.Cast<Roba>().ToList();
            }
        }
    }
}
