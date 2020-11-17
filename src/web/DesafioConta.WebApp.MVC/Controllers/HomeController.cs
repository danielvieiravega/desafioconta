using DesafioConta.WebApp.MVC.Models;
using DesafioConta.WebApp.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DesafioConta.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccountService _accountService;
        private readonly Guid _defaultAccount;

        public HomeController(ILogger<HomeController> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
            //Essa é a conta default cadastrada no banco
            _defaultAccount = Guid.Parse("a0ecf33e-4ffc-49f5-848c-b17e8377573e");
        }

        public async Task<IActionResult> Index()
        {
            var accountSummary = await _accountService.GetSummary(_defaultAccount);
            if (TempData["ShowOperationModal"] != null)
            {
                var showSuccess = TempData["ShowSuccess"] as bool?;
                if (showSuccess.HasValue)
                {
                    accountSummary.ShowOperationModal = true;
                    if (showSuccess.Value)
                        accountSummary.WasSuccessfullOperation = true;
                    else
                        accountSummary.WasSuccessfullOperation = false;
                }
            }
            return View("Index", accountSummary);
        }

        [HttpPost]
        public async Task<IActionResult> Deposit(AcountViewModel model)
        {
            try
            {
                await _accountService.Deposit(_defaultAccount, model.OperationAmount);
                TempData["ShowSuccess"] = true;
            }
            catch (Exception)
            {
                TempData["ShowSuccess"] = false;
            }

            TempData["ShowOperationModal"] = true;

            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public async Task<IActionResult> Withdraw(AcountViewModel model)
        {
            try
            {
                await _accountService.Withdraw(_defaultAccount, model.OperationAmount);
                TempData["ShowSuccess"] = true;
            }
            catch (Exception)
            {
                TempData["ShowSuccess"] = false;
            }

            TempData["ShowOperationModal"] = true;

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Pay(AcountViewModel model)
        {
            try
            {
                await _accountService.Pay(_defaultAccount, model.BoletoCode);
                TempData["ShowSuccess"] = true;
            }
            catch (Exception)
            {
                TempData["ShowSuccess"] = false;
            }

            TempData["ShowOperationModal"] = true;

            return RedirectToAction("Index", "Home");
        }
    }
}
