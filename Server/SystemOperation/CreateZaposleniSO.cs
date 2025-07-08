using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    internal class CreateZaposleniSO : SystemOperationBase
    {
        private readonly Zaposleni z;
        public CreateZaposleniSO(Zaposleni z)
        {
            this.z = z;
        }
        protected override void ExecuteConcreteOperation()
        {
            broker.Add(z);
        }
    }
}
