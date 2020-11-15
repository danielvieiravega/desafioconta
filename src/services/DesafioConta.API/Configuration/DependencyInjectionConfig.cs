using DesafioConta.API.Services;
using DesafioConta.Domain.Accounts;
using DesafioConta.Infra.Boleto;
using DesafioConta.Infra.Data;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioConta.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<CheckingAccountsContext>();
            services.AddScoped<ICheckingAccountRepository, CheckingAccountRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IBoletoHelper, BoletoHelper>();
        }
    }
}
