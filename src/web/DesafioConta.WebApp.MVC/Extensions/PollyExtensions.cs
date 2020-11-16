using Polly;
using Polly.Extensions.Http;
using System;
using System.Net.Http;

namespace DesafioConta.WebApp.MVC.Extensions
{
    public static class PollyExtensions
    {
        public static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(10, TimeSpan.FromSeconds(10));
        }

        public static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            var jitterer = new Random();
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)) + TimeSpan.FromMilliseconds(jitterer.Next(0, 100)));
        }
    }
}
