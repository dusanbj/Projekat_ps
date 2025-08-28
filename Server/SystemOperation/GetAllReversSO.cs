// Server/SystemOperation/GetAllReversSO.cs
using System.Collections.Generic;
using System.Linq;
using Domen;

namespace Server.SystemOperation
{
    public class GetAllReversSO : SystemOperationBase
    {
        public List<Revers> Result { get; private set; }

        protected override void ExecuteConcreteOperation()
        {
            Result = (broker.GetAll(new Revers())?.Cast<Revers>().ToList())
                     ?? new List<Revers>();
        }
    }
}
