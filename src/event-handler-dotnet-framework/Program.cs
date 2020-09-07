using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace event_handler_dotnet_framework
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

                    //Add Handlers
                    services.AddTransient<MessageRecevedHandlerPersistOracle>();
                    services.AddTransient<MessageRecevedHandlerPersistHadoop>();

                    //Get Handlers
                    var serviceProvider = services.BuildServiceProvider();

                    //Add Event as Singleton
                    services.AddSingleton<MessageRecevedEvent>(_ =>
                    {
                        return new MessageRecevedEvent()
                                .AddHandler(serviceProvider.GetService<MessageRecevedHandlerPersistOracle>().OnMessageReceved)
                                .AddHandler(serviceProvider.GetService<MessageRecevedHandlerPersistHadoop>().OnMessageReceved);
                    });
                });
    }
}
