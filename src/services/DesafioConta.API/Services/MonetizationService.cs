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

        private const int MONETIZATION_PERIOD = 30; //Afins de teste, vou deixar 30s ao invés de ser a cada 24 horas

        public MonetizationService(ILogger<MonetizationService> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Serviço de rentabilização de contas iniciado.");

            _timer = new Timer(ProcessAccounts, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(MONETIZATION_PERIOD));

            return Task.CompletedTask;
        }

        private async void ProcessAccounts(object state)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                //FAzer aqui a rentabilização da conta
            }
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
