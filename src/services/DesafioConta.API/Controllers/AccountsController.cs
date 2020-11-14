using DesafioConta.Domain.Accounts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DesafioConta.API.Controllers
{
    [Route("api/accounts")]
    public class AccountsController : MainController
    {
        private readonly ICheckingAccountRepository _checkingAccountRepository;

        public AccountsController(ICheckingAccountRepository checkingAccountRepository)
        {
            _checkingAccountRepository = checkingAccountRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var xuxu = await _checkingAccountRepository.GetAll();
            return Ok(xuxu);
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }
    }
}
