using DesafioConta.Core.DomainObjects;
using System;

namespace DesafioConta.Domain.Accounts
{
    public class OperationsHistory : SoftDeleteEntity
    {
        //public Guid CheckingAccountId { get; private set; }
        public Operation Operation { get; private set; }
        public decimal Amount { get; private set; }
        public CheckingAccount CheckingAccount { get; set; }

        protected OperationsHistory() { }

        public OperationsHistory(Operation operation, decimal amount/*, Guid checkingAccountId*/)
        {
            Operation = operation;
            Amount = amount;
            //CheckingAccountId = checkingAccountId;
        }
    }
}
