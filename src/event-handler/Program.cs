using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using event_handler.CrossCutting;
using event_handler.Events;
using event_handler.Handlers;
using event_handler.Stubs;
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
                    services.AddTransient<IEventHandler<MessageReceived>, MessageRecevedHandlerPersistOracle>();
                    services.AddTransient<IEventHandler<MessageReceived>, MessageRecevedHandlerSMS>();
                    services.AddTransient<IEventHandler<MessageReceived>, MessageRecevedHandlerHttp>();

                    // Add Gateways
                    services.AddTransient<IConsumeKafkaGateway, ConsumeKafkaGatewayStub>();
                    services.AddTransient<ISendMessageHttpGateway, SendMessageHttpGateway>();

                    // Configure Services RaiseEvents
                    var serviceProvider = services.BuildServiceProvider();
                    RaiseEvents.Services = serviceProvider;

                });
    }
}
