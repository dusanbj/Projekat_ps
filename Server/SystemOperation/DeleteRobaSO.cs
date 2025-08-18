using Domen;

namespace Server.SystemOperation
{
    public class DeleteRobaSO : SystemOperationBase
    {
        private readonly Roba roba;
        public DeleteRobaSO(Roba roba) { this.roba = roba; }

        protected override void ExecuteConcreteOperation()
        {
            broker.Delete(roba);
        }
    }
}
