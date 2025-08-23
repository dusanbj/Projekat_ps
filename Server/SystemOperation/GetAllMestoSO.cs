using Common.Domain;
using Domen;
using System.Collections.Generic;
using System.Linq;

namespace Server.SystemOperation
{
    public class GetAllMestoSO : SystemOperationBase
    {
        public List<Mesto> Result { get; private set; }

        protected override void ExecuteConcreteOperation()
        {
            Result = broker.GetAll(new Mesto()).Cast<Mesto>().ToList();
        }
    }
}