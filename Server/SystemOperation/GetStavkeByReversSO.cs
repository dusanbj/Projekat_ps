// Server/SystemOperation/GetStavkeByReversSO.cs
using System;
using System.Collections.Generic;
using System.Linq;
using Domen;

namespace Server.SystemOperation
{
    public class GetStavkeByReversSO : SystemOperationBase
    {
        private readonly long _idRevers;
        public List<StavkaReversa> Result { get; private set; }

        public GetStavkeByReversSO(long idRevers)
        {
            _idRevers = idRevers;
        }

        protected override void ExecuteConcreteOperation()
        {
            if (_idRevers <= 0) throw new Exception("Nevalidan idRevers.");

            Result = broker.GetByCondition(new StavkaReversa(), $"idRevers = {_idRevers}")
                           .Cast<StavkaReversa>()
                           .ToList();
        }
    }
}
