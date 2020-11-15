using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DesafioConta.API.Services
{
    public class MonetizationService : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly ILogger<MonetizationService> _logger;
        private readonly IServiceProvider _serviceProvider;

        //Para que seja vísivel o funcionamento rentabilização vou deixar 30s ao invés de ser a cada 24hrs
        private const int MonetizationPeriod = 30;

        public MonetizationService(ILogger<MonetizationService> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Serviço de rentabilização de contas iniciado.");

            _timer = new Timer(ProcessAccounts, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(MonetizationPeriod));

            return Task.CompletedTask;
        }

        private async void ProcessAccounts(object state)
        {
            using var scope = _serviceProvider.CreateScope();
            var accountService = scope.ServiceProvider.GetRequiredService<IAccountService>();
            await accountService.Monetize();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Serviço de rentabilização de contas finalizado.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
