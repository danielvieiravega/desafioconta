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
            _defaultAccount = Guid.Parse("A0ECF33E-4FFC-49F5-848C-B17E8377573E");
        }

        public async Task<IActionResult> Index()
        {
            var accountSummary = await _accountService.GetSummary(_defaultAccount);
            if (TempData["showSuccess"] != null)
            {
                //bool value = TempData["showSuccess"] as bool;

                accountSummary.ShowSuccessOperation = true;
            }
            return View("Index", accountSummary);
        }

        [HttpPost]
        public async Task<IActionResult> Deposit(AcountViewModel model)
        {
            try
            {
                await _accountService.Deposit(_defaultAccount, model.OperationAmount);
                TempData["showSuccess"] = true;
            }
            catch (Exception)
            {
                TempData["showSuccess"] = false;
            }
            

            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public async Task<IActionResult> Withdraw(AcountViewModel model)
        {
            try
            {
                await _accountService.Withdraw(_defaultAccount, model.OperationAmount);
                TempData["showSuccess"] = true;
            }
            catch (Exception)
            {
                TempData["showSuccess"] = false;
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Pay(AcountViewModel model)
        {
            var showSucccess = false;

            try
            {
                await _accountService.Pay(_defaultAccount, model.BoletoCode);
                showSucccess = true;

            }
            catch (Exception)
            {
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
