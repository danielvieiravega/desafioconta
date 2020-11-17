using DesafioConta.API.Services;
using DesafioConta.Core.DomainObjects;
using DesafioConta.Domain.Accounts;
using DesafioConta.Domain.Data;
using DesafioConta.Infra.Boleto;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DesafioConta.Tests
{
    public class AccountServiceTests
    {
        private readonly IAccountService _accountService;
        private readonly CheckingAccount _account;
        private readonly ICheckingAccountRepository _accountRepository;

        public AccountServiceTests()
        {
            _account = CreateAccount();

            var accountRepository = new Mock<ICheckingAccountRepository>();

            accountRepository.Setup(a => a.GetById(_account.Id))
               .ReturnsAsync(_account);

            accountRepository.Setup(a => a.GetAll())
               .ReturnsAsync(new List<CheckingAccount>() { _account });

            var uowMock = new Mock<IUnitOfWork>();

            accountRepository.Setup(a => a.UnitOfWork)
                .Returns(uowMock.Object);

            _accountRepository = accountRepository.Object;

            _accountService = new AccountService(accountRepository.Object, new BoletoHelper());
        }
        
        private CheckingAccount CreateAccount()
        {
            return new CheckingAccount(1);
        }

        [Fact]
        public async Task AccountService_Deposit_ShouldRunWithSuccess()
        {
            var depositValue = CheckingAccount.MinDepositAmountValue + 1;
            await _accountService.Deposit(_account.Id, depositValue);

            var account = await _accountRepository.GetById(_account.Id);
            Assert.Equal(depositValue, account.Balance);
            Assert.Equal(1, account.OperationsHistory.Count);
            Assert.Equal(Operation.Deposit, account.OperationsHistory.Last().Operation);
            Assert.Equal(depositValue, account.OperationsHistory.Last().Amount);
        }

        [Fact]
        public async Task AccountService_Pay_ShouldRunWithSuccessPayingValidBoleto()
        {
            var depositValue = 500m;
            var boletoValue = 158.47m;

            var account = await _accountRepository.GetById(_account.Id);
            await _accountService.Deposit(_account.Id, depositValue);
            
            var validBoletCode = "07790.00116 44000.000511 01612.636645 8 84410000015847";
            await _accountService.Pay(_account.Id, validBoletCode);

            Assert.Equal(2, account.OperationsHistory.Count);
            Assert.Equal(Operation.Payment, account.OperationsHistory.Last().Operation);
            Assert.Equal(depositValue - boletoValue, account.Balance);
        }

        [Fact]
        public async Task AccountService_Pay_ShouldFailDueInvalidBoletoCode()
        {
            var depositValue = 500m;
            var account = await _accountRepository.GetById(_account.Id);
            await _accountService.Deposit(_account.Id, depositValue);

            var invalidBoletCode = "gsfdfgsgrsfagsagsaagsd";
            var exception = await Assert.ThrowsAsync<Exception>(() => _accountService.Pay(_account.Id, invalidBoletCode));
            Assert.Equal("Invalid Boleto code", exception.Message);
        }

        [Fact]
        public async Task AccountService_Withdraw_ShouldRunWithSuccess()
        {
            var depositValue = 500m;

            await _accountService.Deposit(_account.Id, depositValue);
            await _accountService.Withdraw(_account.Id, depositValue);

            var account = await _accountRepository.GetById(_account.Id);
            Assert.Equal(2, account.OperationsHistory.Count);
            Assert.Equal(Operation.Withdraw, account.OperationsHistory.Last().Operation);
        }

        [Fact]
        public async Task AccountService_Deposit_ShouldFailDueInvalidAccount()
        {
            var invalidAccountGuid = Guid.NewGuid();
            var depositValue = CheckingAccount.MinDepositAmountValue + 1;
            var exception = await Assert.ThrowsAsync<DomainException>(() => _accountService.Deposit(invalidAccountGuid, depositValue));
            Assert.Equal("Account not found: " + invalidAccountGuid, exception.Message);
        }

        [Fact]
        public async Task AccountService_Monetize_ShouldRunWithSuccess()
        {
            var depositValue = CheckingAccount.MinDepositAmountValue + 1;
            await _accountService.Deposit(_account.Id, depositValue);

            Assert.Equal(0, _account.Yield);
            await _accountService.Monetize();
            Assert.True(_account.Yield > 0);
        }
    }
}
