using DesafioConta.API.Controllers.Model;
using DesafioConta.API.Services;
using DesafioConta.WebAPI.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace DesafioConta.API.Controllers
{
    [Route("api/accounts")]
    public class AccountsController : MainController
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetAccountSummaryModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var accountSummary = await _accountService.GetSummary(id);
            return Ok(accountSummary);
        }
    }
}
