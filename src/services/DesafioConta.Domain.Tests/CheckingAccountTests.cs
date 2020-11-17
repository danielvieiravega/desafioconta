using DesafioConta.Core.DomainObjects;
using DesafioConta.Domain.Accounts;
using Xunit;

namespace DesafioConta.Tests
{
    public class CheckingAccountTests
    {
        [Fact]
        public void CheckingAccount_NewCheckingAcount_ShouldBeInvalid()
        {
            Assert.Throws<DomainException>(() => new CheckingAccount(0));
        }

        [Fact]
        public void CheckingAccount_Deposit_ShouldRunWithSuccess()
        {
            var account = new CheckingAccount(1);

            var depositValue = 100.0m;
            account.Deposit(depositValue);
            Assert.Equal(depositValue, account.Balance);
        }

        [Fact]
        public void CheckingAccount_Deposit_ShouldRaiseExceptionDueDepositAmountLessThanMinAllowed()
        {
            var account = new CheckingAccount(1);
            Assert.Throws<DomainException>(() => account.Deposit(CheckingAccount.MinDepositAmountValue - 1));
        }

        [Fact]
        public void CheckingAccount_Deposit_ShouldRaiseExceptionDueDepositAmountGreaterThanMaxAllowed()
        {
            var account = new CheckingAccount(1);
            Assert.Throws<DomainException>(() => account.Deposit(CheckingAccount.MaxDepositAmountValue + 1));
        }

        [Fact]
        public void CheckingAccount_Withdraw_ShouldRunWithSuccess()
        {
            var account = new CheckingAccount(1);

            var depositValue = 100.0m;
            var expectedBalance = 50.0m;
            account.Deposit(depositValue);
            account.WithDraw(50);
            Assert.Equal(expectedBalance, account.Balance);
        }

        [Fact]
        public void CheckingAccount_Withdraw_ShouldRaiseExceptionDueWithdrawAmountLessThanMinAllowed()
        {
            var account = new CheckingAccount(1);
            Assert.Throws<DomainException>(() => account.WithDraw(CheckingAccount.MinWithDrawAmountValue - 1));
        }

        [Fact]
        public void CheckingAccount_Withdraw_ShouldRaiseExceptionDueWithdrawAmountGreaterThanMaxAllowed()
        {
            var account = new CheckingAccount(1);
            Assert.Throws<DomainException>(() => account.WithDraw(CheckingAccount.MaxWithDrawAmountValue + 1));
        }

        [Fact]
        public void CheckingAccount_Withdraw_ShouldRaiseExceptionDueWithdrawAmountGreaterThanBalance()
        {
            var account = new CheckingAccount(1);

            var depositValue = 100.0m;
            account.Deposit(depositValue);

            Assert.Throws<DomainException>(() => account.WithDraw(depositValue + 1));
        }

        [Fact]
        public void CheckingAccount_Payment_ShouldRunWithSuccess()
        {
            var account = new CheckingAccount(1);

            var depositValue = 100.0m;
            var expectedBalance = 50.0m;
            account.Deposit(depositValue);
            account.Pay(50);
            Assert.Equal(expectedBalance, account.Balance);
        }

        [Fact]
        public void CheckingAccount_Payment_ShouldRaiseExceptionDuePaymentAmountLessThanMinAllowed()
        {
            var account = new CheckingAccount(1);
            Assert.Throws<DomainException>(() => account.Pay(CheckingAccount.MinPaymentAmountValue- 1));
        }

        [Fact]
        public void CheckingAccount_Payment_ShouldRaiseExceptionDuePaymentAmountGreaterThanMaxAllowed()
        {
            var account = new CheckingAccount(1);
            Assert.Throws<DomainException>(() => account.Pay(CheckingAccount.MaxPaymentAmountValue + 1));
        }

        [Fact]
        public void CheckingAccount_Remunerate_ShouldRunWithSuccess()
        {
            var account = new CheckingAccount(1);
            var depositValue = 100.0m;
            account.Deposit(depositValue);
            Assert.Equal(depositValue, account.Balance);
            Assert.Equal(0, account.Yield);
            account.Remunerate();

            var expectedYield = account.Balance * CheckingAccount.DailyRemunerationRate;

            Assert.Equal(decimal.Round(expectedYield, 5), decimal.Round(account.Yield, 5));
        }
    }
}
