using Domen;
using Server.SystemOperation;

namespace Server
{
    internal class UpdateZaposleni : SystemOperationBase
    {
        private readonly Zaposleni z;
        public UpdateZaposleni(Zaposleni z)
        {
            this.z = z;
        }
        protected override void ExecuteConcreteOperation()
        {
            broker.Update(z);
        }
    }
}