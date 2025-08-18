using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public class DeleteZaposleniSO : SystemOperationBase
    {
        private readonly Zaposleni z;
        public DeleteZaposleniSO(Zaposleni z)
        {
            this.z = z;
        }
        protected override void ExecuteConcreteOperation()
        {
            broker.Delete(z);
        }
    }
}
