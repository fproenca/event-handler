using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace event_handler_generic
{
    class Program
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
                    services.AddTransient<MessageRecevedArgs>();

                    //Add Handlers
                    services.AddTransient<IHandler<MessageRecevedHandlerPersistOracle, MessageRecevedArgs>, MessageRecevedHandlerPersistOracle>();
                    services.AddTransient<IHandler<MessageRecevedHandlerPersistHadoop, MessageRecevedArgs>, MessageRecevedHandlerPersistHadoop>();

                    //Get Handlers
                    var serviceProvider = services.BuildServiceProvider();
                    var messageRecevedHandlerPersistOracle = serviceProvider.GetService<IHandler<MessageRecevedHandlerPersistOracle, MessageRecevedArgs>>();
                    var messageRecevedHandlerPersistHadoop = serviceProvider.GetService<IHandler<MessageRecevedHandlerPersistHadoop, MessageRecevedArgs>>();

                    //Add Event as Singleton
                    services.AddSingleton<IEvent<MessageReceved, MessageRecevedArgs>, MessageReceved>(_ =>
                    {
                        return new MessageReceved()
                                .AddHandler(eventArgs => messageRecevedHandlerPersistOracle.OnEventAsync(eventArgs))
                                .AddHandler(eventArgs => messageRecevedHandlerPersistHadoop.OnEventAsync(eventArgs));
                    });

                });
    }
}
