using DesafioConta.WebApp.MVC.Extensions;
using DesafioConta.WebApp.MVC.Models;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DesafioConta.WebApp.MVC.Services
{
    public interface IAccountService
    {
        Task<AcountViewModel> GetSummary(Guid id);
        Task Deposit(Guid id, decimal amount);
        Task Withdraw(Guid id, decimal amount);
        Task Pay(Guid id, string boletoCode);
    }

    public class AccountService : Service, IAccountService
    {
        private readonly HttpClient _httpClient;

        public AccountService(HttpClient httpClient,
            IOptions<AppSettings> settings)
        {
            httpClient.BaseAddress = new Uri(settings.Value.AccountUrl);

            _httpClient = httpClient;
        }

        public async Task<AcountViewModel> GetSummary(Guid id)
        {
            var response = await _httpClient.GetAsync($"/api/accounts/{id}");

            TreatResponseErrors(response);

            return await DeserializeResponseObject<AcountViewModel>(response);
        }

        public async Task Deposit(Guid id, decimal amount)
        {
            var obj = new { amount };

            var content = GetContent(obj);

            var response = await _httpClient.PostAsync($"/api/accounts/{id}/deposits", content);

            TreatResponseErrors(response);
        }

        public async Task Pay(Guid id, string boletoCode)
        {
            var obj = new { boletoCode };

            var content = GetContent(obj);

            var response = await _httpClient.PostAsync($"/api/accounts/{id}/payments", content);

            TreatResponseErrors(response);
        }

        public async Task Withdraw(Guid id, decimal amount)
        {
            var obj = new { amount };

            var content = GetContent(obj);

            var response = await _httpClient.PostAsync($"/api/accounts/{id}/withdraw", content);

            TreatResponseErrors(response);
        }
    }
}
