using DesafioConta.Core.DomainObjects;
using System;
using System.Collections.Generic;

namespace DesafioConta.Domain.Accounts
{
    public class CheckingAccount : Account
    {
        public const decimal MinDepositAmountValue = 5;
        public const decimal MaxDepositAmountValue = 100000;

        public const decimal MinWithDrawAmountValue = 10;
        public const decimal NaxWithDrawAmountValue = 100000;

        public int Agency { get; private set; }
        public int Number { get; private set; }
        public DateTime LastMonetization { get; private set; }
        public Customer Customer { get; private set; }

        private readonly List<OperationsHistory> _operationsHistory;

        public IReadOnlyCollection<OperationsHistory> OperationsHistory => _operationsHistory;

        //construtor do EF
        protected CheckingAccount()
        {
        }

        public CheckingAccount(int number)
        {
            if (number < 0)
                throw new DomainException("number should be greather than 0");

            Agency = 1;
            Number = number;
            Balance = 0;
            LastMonetization = DateTime.Now;

            _operationsHistory = new List<OperationsHistory>();
        }

        public override void Deposit(decimal amount)
        {
            if (amount < MinDepositAmountValue)
                throw new DomainException($"The ammount to be deposited must be greater than {MinDepositAmountValue}");

            if (amount > MaxDepositAmountValue)
                throw new DomainException($"The ammount to be deposited must be less than {MaxDepositAmountValue}");

            Balance += amount;

            SaveOperation(amount, Operation.Deposit);
        }

        public override void WithDraw(decimal amount)
        {
            if (amount < MinWithDrawAmountValue)
                throw new DomainException($"The ammount to be withdrawn must be greater than {MinWithDrawAmountValue}");

            if (amount > NaxWithDrawAmountValue)
                throw new DomainException($"The ammount to be withdrawn must be less than {NaxWithDrawAmountValue}");
            
            if (Balance >= amount)
            {
                Balance -= amount;
                SaveOperation(amount, Operation.WithDraw);
            }
        }

        private void SaveOperation(decimal amount, Operation operation)
        {
            _operationsHistory.Add(new OperationsHistory(operation, amount/*, Id*/));
        }
    }
}
