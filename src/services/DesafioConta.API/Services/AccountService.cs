using DesafioConta.API.Controllers.Model;
using DesafioConta.Domain.Accounts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioConta.API.Services
{
    public interface IAccountService
    {
        Task Deposit(Guid id, decimal value);
        Task Withdraw(Guid id, decimal value);
        Task Monetize();
        Task Pay(Guid id, string boletoCode);

        Task<GetAccountSummaryModel> GetSummary(Guid id);
    }

    public class AccountService : IAccountService
    {
        private readonly ICheckingAccountRepository _checkingAccountRepository;
        private readonly IBoletoHelper _boletoValidator;

        public AccountService(ICheckingAccountRepository checkingAccountRepository, IBoletoHelper boletoHelper)
        {
            _checkingAccountRepository = checkingAccountRepository;
            _boletoValidator = boletoHelper;
        }

        public async Task Deposit(Guid id, decimal value)
        {
            var account = await _checkingAccountRepository.GetById(id);
            account.Deposit(value);

            await _checkingAccountRepository.UnitOfWork.CommitAsync();
        }

        public async Task Withdraw(Guid id, decimal value)
        {
            var account = await _checkingAccountRepository.GetById(id);
            account.WithDraw(value);

            await _checkingAccountRepository.UnitOfWork.CommitAsync();
        }

        public async Task Monetize()
        {
            var accounts = await _checkingAccountRepository.GetAll();
            foreach(var account in accounts)
                account.Remunerate();

            await _checkingAccountRepository.UnitOfWork.CommitAsync();
        }

        public async Task Pay(Guid id, string boletoCode)
        {
            var chargeAmount = _boletoValidator.GetChargeAmount(boletoCode);
            var account = await _checkingAccountRepository.GetById(id);
            account.Pay(chargeAmount);

            await _checkingAccountRepository.UnitOfWork.CommitAsync();
        }

        public async Task<GetAccountSummaryModel> GetSummary(Guid id)
        {
            var account = await _checkingAccountRepository.GetById(id);

            var accountSummary = new GetAccountSummaryModel
            {
                Balance = account.Balance,
                Yield = account.Yield,
                OperationsHistory = account.OperationsHistory
                                           .OrderByDescending(h => h.CreationDate)
                                           .Take(10)
                                           .Select(h =>
                                               new OperationsHistoryModel
                                               {
                                                   Amount = h.Amount,
                                                   Operation = (int)h.Operation,
                                                   DateTime = h.CreationDate
                                               }
                                            ).ToList()
            };

            return accountSummary;
        }
    }
}
