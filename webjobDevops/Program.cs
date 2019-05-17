using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace webjobDevops
{
    // To learn more about Microsoft Azure WebJobs SDK, please see https://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        static void Main()
        {
            var builder = new HostBuilder()
                   .UseEnvironment("Development")
                   .ConfigureWebJobs(b =>
                   {
                       b.AddAzureStorageCoreServices()
                       .AddAzureStorage()
                       .AddServiceBus()
                       .AddEventHubs()
                       .AddTimers();
                   })
                   
                   .ConfigureLogging((context, b) =>
                   {
                       b.SetMinimumLevel(LogLevel.Debug);
                       b.AddConsole();

                    // If this key exists in any config, use it to enable App Insights
                    string appInsightsKey = context.Configuration["APPINSIGHTS_INSTRUMENTATIONKEY"];
                       if (!string.IsNullOrEmpty(appInsightsKey))
                       {
                           b.AddApplicationInsights(o => o.InstrumentationKey = appInsightsKey);
                       }
                   })
                   .ConfigureServices(services =>
                   {
                    // add some sample services to demonstrate job class DI
                  //  services.AddSingleton<ISampleServiceA, SampleServiceA>();
                    //   services.AddSingleton<ISampleServiceB, SampleServiceB>();
                   })
                   .UseConsoleLifetime();

            var host = builder.Build();
            using (host)
            {
                 host.Run();
            }
        }
    
}
}
