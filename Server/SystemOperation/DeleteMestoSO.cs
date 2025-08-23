using Domen;

namespace Server.SystemOperation
{
    public class DeleteMestoSO : SystemOperationBase
    {
        private readonly Mesto _mesto;
        public DeleteMestoSO(Mesto mesto) { _mesto = mesto; }

        protected override void ExecuteConcreteOperation()
        {
            broker.Delete(_mesto);
        }
    }
}
