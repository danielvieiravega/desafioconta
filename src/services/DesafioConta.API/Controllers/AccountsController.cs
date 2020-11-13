using DesafioConta.Domain.Accounts;
using Microsoft.AspNetCore.Mvc;

namespace DesafioConta.API.Controllers
{
    public class AccountsController : MainController
    {
        private readonly ICheckingAccountRepository _checkingAccountRepository;

        public AccountsController(ICheckingAccountRepository checkingAccountRepository)
        {
            _checkingAccountRepository = checkingAccountRepository;
        }


        [HttpGet]
        public IActionResult Get()
        {
            
            return Ok();
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }
    }
}
