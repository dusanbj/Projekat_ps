// Server/SystemOperation/GetAllZaposleniSO.cs
using System.Collections.Generic;
using System.Linq;
using Domen;

namespace Server.SystemOperation
{
    public class GetAllZaposleniSO : SystemOperationBase
    {
        public List<Zaposleni> Result { get; private set; }

        protected override void ExecuteConcreteOperation()
        {
            Result = (broker.GetAll(new Zaposleni())?.Cast<Zaposleni>().ToList())
                     ?? new List<Zaposleni>();
        }
    }
}
