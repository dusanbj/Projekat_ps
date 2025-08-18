using Domen;

namespace Server.SystemOperation
{
    public class UpdateRobaSO : SystemOperationBase
    {
        private readonly Roba roba;
        public UpdateRobaSO(Roba roba) { this.roba = roba; }

        protected override void ExecuteConcreteOperation()
        {
            broker.Update(roba);
        }
    }
}