using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace event_handler_generic
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IEvent<MessageReceved, MessageRecevedArgs> _messageReceved;
        private readonly MessageRecevedArgs _messageRecevedArgs;

        public Worker(ILogger<Worker> logger, MessageRecevedArgs messageRecevedArgs,
                        IEvent<MessageReceved, MessageRecevedArgs> messageReceved)
        {
            _logger = logger;
            _messageRecevedArgs = messageRecevedArgs;
            _messageReceved = messageReceved;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _messageRecevedArgs.Message.Description = "Message Receved!";
                _messageReceved.Raise(_messageRecevedArgs);

                _logger.LogInformation("Continue gateway...");

                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}
