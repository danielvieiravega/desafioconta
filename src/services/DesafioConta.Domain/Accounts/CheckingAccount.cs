using DesafioConta.Core.DomainObjects;
using System;
using System.Collections.Generic;

namespace DesafioConta.Domain.Accounts
{
    public class CheckingAccount : SoftDeleteEntity, IAggregateRoot
    {
        public const decimal MIN_DEPOSIT_AMOUNT_VALUE = 5;
        public const decimal MAX_DEPOSIT_AMOUNT_VALUE = 100000;

        public const decimal MIN_WITHDRAW_AMOUNT_VALUE = 10;
        public const decimal MAX_WITHDRAW_AMOUNT_VALUE = 100000;

        public int Agency { get; private set; }
        public int Number { get; private set; }
        public Holder Holder { get; private set; }
        public DateTime LastMonetization { get; private set; }

        public decimal Balance { get; protected set; }

        private readonly List<OperationsHistory> _operationsHistory;
        public IReadOnlyCollection<OperationsHistory> OperationsHistory => _operationsHistory;

        //construtor do EF
        protected CheckingAccount()
        {
        }

        public CheckingAccount(int number, Holder holder)
        {
            if (number < 0)
                throw new DomainException("number should be greather than 0");

            Agency = 1;
            Number = number;
            Holder = holder;
            Balance = 0;
            LastMonetization = DateTime.Now;

            _operationsHistory = new List<OperationsHistory>();
        }

        public  void Deposit(decimal amount)
        {
            if (amount < MIN_DEPOSIT_AMOUNT_VALUE)
                throw new DomainException($"The ammount to be deposited must be greater than {MIN_DEPOSIT_AMOUNT_VALUE}");

            if (amount > MAX_DEPOSIT_AMOUNT_VALUE)
                throw new DomainException($"The ammount to be deposited must be less than {MAX_DEPOSIT_AMOUNT_VALUE}");

            Balance += amount;

            SaveOperation(amount, Operation.Deposit);
        }

        public  void WithDraw(decimal amount)
        {
            if (amount < MIN_WITHDRAW_AMOUNT_VALUE)
                throw new DomainException($"The ammount to be withdrawn must be greater than {MIN_WITHDRAW_AMOUNT_VALUE}");

            if (amount > MAX_WITHDRAW_AMOUNT_VALUE)
                throw new DomainException($"The ammount to be withdrawn must be less than {MAX_WITHDRAW_AMOUNT_VALUE}");
            
            if (Balance >= amount)
            {
                Balance -= amount;
                SaveOperation(amount, Operation.WithDraw);
            }
        }

        private void SaveOperation(decimal amount, Operation operation)
        {
            _operationsHistory.Add(new OperationsHistory(operation, amount));
        }
    }
}
