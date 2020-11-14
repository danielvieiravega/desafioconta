using DesafioConta.Domain.Accounts;
using DesafioConta.WebAPI.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DesafioConta.API.Controllers
{
    public class DepositModel
    {
        public decimal Amount { get; set; }
    }

    [Route("api/accounts/{id}/deposits")]
    public class AccountsDepositsController : MainController
    {
        private readonly ICheckingAccountRepository _checkingAccountRepository;

        public AccountsDepositsController(ICheckingAccountRepository checkingAccountRepository)
        {
            _checkingAccountRepository = checkingAccountRepository;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post(Guid id, DepositModel model)
        {
            var account = await _checkingAccountRepository.GetById(id);

            account.Deposit(model.Amount);

            //_checkingAccountRepository.Update(account);

            if (_checkingAccountRepository.UnitOfWork.Commit())
                return Ok();

            return BadRequest();
        }
    }
}
