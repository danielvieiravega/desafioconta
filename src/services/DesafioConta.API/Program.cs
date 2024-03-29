using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DesafioConta.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    //Para exemplificar estou gravando o log no console, mas no mundo real geralmente gravo no MongoDB
                    logging.AddConsole();
                    logging.AddDebug();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                 .ConfigureAppConfiguration((hostingContext, config) =>
                 {
                     var env = hostingContext.HostingEnvironment;
                     config.SetBasePath(env.ContentRootPath)
                     .AddJsonFile("AppSettings.json", true, true)
                     .AddJsonFile($"AppSettings.{env.EnvironmentName}.json", true, true)
                     .AddEnvironmentVariables();
                 });
    }
}
