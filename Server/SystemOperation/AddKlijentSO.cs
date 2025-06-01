using Common.Domain;
using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public class AddKlijentSO : SystemOperationBase
    {
        private readonly Klijent p;

        public AddKlijentSO(Klijent p)
        {
            this.p = p;
        }
        protected override void ExecuteConcreteOperation()
        {
            broker.Add(p);
        }
    }
}