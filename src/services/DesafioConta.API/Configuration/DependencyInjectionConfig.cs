using DesafioConta.Domain.Accounts;
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

        }
    }
}
