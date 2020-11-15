using DesafioConta.Core.DomainObjects;

namespace DesafioConta.Domain.Accounts
{
    public class OperationsHistory : SoftDeleteEntity
    {
        public Operation Operation { get; private set; }
        public decimal Amount { get; private set; }
        public CheckingAccount CheckingAccount { get; set; }

        protected OperationsHistory() { }

        public OperationsHistory(Operation operation, decimal amount)
        {
            Operation = operation;
            Amount = amount;
        }
    }
}
