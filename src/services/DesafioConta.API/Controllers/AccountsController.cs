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
            var number = 1;
            var name = new Name("Jose", "da Silva");
            var cpf = new Cpf("03480365078");
            var address = new Address();

            var holder = new Holder(name, cpf, address);

            var newAccount = new CheckingAccount(number, holder);

            return Ok();
        }
    }
}
