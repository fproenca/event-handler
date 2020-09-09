using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using event_handler.Events;
using event_handler.Handlers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace event_handler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();

                    // Add Handlers
                    services.AddTransient<IEventHandler<MessageReceved>, MessageRecevedHandlerPersistOracle>();
                    services.AddTransient<IEventHandler<MessageReceved>, MessageRecevedHandlerSMS>();

                    // Configure Services RaiseEvents
                    var serviceProvider = services.BuildServiceProvider();
                    RaiseEvents.Services = serviceProvider;

                });
    }
}
