using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.SystemOperation
{
    public class GetKlijentSO : SystemOperationBase
    {
        public List<Klijent> Result {  get; private set; }  
        protected override void ExecuteConcreteOperation()
        {
            //get by condition
        }
    }
}
