using DesafioConta.Core.DomainObjects;
using System;
using System.Collections.Generic;

namespace DesafioConta.Domain.Accounts
{
    public class CheckingAccount : Account
    {
        public const decimal MinDepositAmountValue = 5;
        public const decimal MaxDepositAmountValue = 100005;

        public const decimal MinWithDrawAmountValue = 10;
        public const decimal MaxWithDrawAmountValue = 100010;

        public const decimal MinPaymentAmountValue = 15;
        public const decimal MaxPaymentAmountValue = 100015;
        
        public const decimal DailyRemunerationRate = 0.0000747m; //Taxa selic no dia 16/11

        public int Agency { get; private set; }
        public int Number { get; private set; }
        public DateTime LastMonetization { get; private set; }
        public Customer Customer { get; private set; }
        public decimal Yield { get; protected set; }

        private readonly List<OperationsHistory> _operationsHistory;
        public IReadOnlyCollection<OperationsHistory> OperationsHistory => _operationsHistory;

        protected CheckingAccount(){}

        public CheckingAccount(int number)
        {
            if (number < 1)
                throw new DomainException("number should be greather than 1");

            Agency = 1;
            Number = number;
            Balance = 0;
            Yield = 0;
            LastMonetization = DateTime.Now;
            _operationsHistory = new List<OperationsHistory>();
        }

        public override void Deposit(decimal amount)
        {
            if (amount < MinDepositAmountValue)
                throw new DomainException($"The amount to be deposited must be greater than {MinDepositAmountValue}");

            if (amount > MaxDepositAmountValue)
                throw new DomainException($"The amount to be deposited must be less than {MaxDepositAmountValue}");

            Balance += amount;
            SaveOperation(amount, Operation.Deposit);
        }

        public override void WithDraw(decimal amount)
        {
            if (amount < MinWithDrawAmountValue)
                throw new DomainException($"The amount to be withdrawn must be greater than {MinWithDrawAmountValue}");

            if (amount > MaxWithDrawAmountValue)
                throw new DomainException($"The amount to be withdrawn must be less than {MaxWithDrawAmountValue}");
            
            if (amount > Balance)
                throw new DomainException("The amount to be withdrawn must be less then your total balance");

            Balance -= amount;
            SaveOperation(amount, Operation.Withdraw);
        }

        public void Remunerate()
        {
            var yield = (Balance * DailyRemunerationRate);
            Balance += yield;
            Yield += yield;
        }

        public void Pay(decimal amount)
        {
            if (amount > Balance)
                throw new DomainException("The amount to be pay must be less then your total balance");

            Balance -= amount;
            SaveOperation(amount, Operation.Payment);
        }

        private void SaveOperation(decimal amount, Operation operation)
        {
            _operationsHistory.Add(new OperationsHistory(operation, amount));
        }
    }
}
