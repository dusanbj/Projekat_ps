using Domen;

namespace Server.SystemOperation
{
    internal class UpdateZaposleniSO : SystemOperationBase
    {
        private readonly Zaposleni z;
        public UpdateZaposleniSO(Zaposleni z)
        {
            this.z = z;
        }
        protected override void ExecuteConcreteOperation()
        {
            broker.Update(z);
        }
    }
}