using Domen;

namespace Server.SystemOperation
{
    public class CreateRobaSO : SystemOperationBase
    {
        private readonly Roba roba;
        public CreateRobaSO(Roba roba) { this.roba = roba; }

        protected override void ExecuteConcreteOperation()
        {
            broker.Add(roba);
        }
    }
}