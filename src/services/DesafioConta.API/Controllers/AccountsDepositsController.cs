using DesafioConta.API.Controllers.Model;
using DesafioConta.API.Services;
using DesafioConta.WebAPI.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace DesafioConta.API.Controllers
{
    [Route("api/accounts/{id}/deposits")]
    public class AccountsDepositsController : MainController
    {
        private readonly IAccountService _accountService;

        public AccountsDepositsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post(Guid id, AccountModel model)
        {
            await _accountService.Deposit(id, model.Amount);

            return Ok();
        }
    }
}
