using DesafioConta.API.Controllers.Model;
using DesafioConta.API.Services;
using DesafioConta.WebAPI.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace DesafioConta.API.Controllers
{
    public class AccountPaymentModel
    {
        public string BoletoCode { get; set; }
    }


    [Route("api/accounts/{id}/payments")]
    public class AccountsPaymentsController : MainController
    {
        private readonly IAccountService _accountService;

        public AccountsPaymentsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post(Guid id, AccountPaymentModel model)
        {
            await _accountService.Pay(id, model.BoletoCode);

            return Ok();
        }
    }
}
