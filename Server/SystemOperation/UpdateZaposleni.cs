using Domen;

namespace Server.SystemOperation
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