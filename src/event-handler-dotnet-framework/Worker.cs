using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace event_handler_dotnet_framework
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly MessageRecevedEvent _messageRecevedEvent;

        public Worker(ILogger<Worker> logger, MessageRecevedEvent messageRecevedEvent)
        {
            _logger = logger;
            _messageRecevedEvent = messageRecevedEvent;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var args = new MessageEventArgs();
                args.Message.Description = "Message Receved!";
                
                // You can use this with ou without await
                //await _messageRecevedEvent.Raise(args);
                _messageRecevedEvent.Raise(args);

                await Task.Delay(3000, stoppingToken);
            }
        }
    }
}
