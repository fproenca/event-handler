using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using event_handler.Events;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using event_handler.Handlers;

namespace event_handler
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // There are three ways to use it
                RaiseEvents.RaiseAsync(new MessageReceved());
                await RaiseEvents.RaiseAsync(new MessageReceved());
                RaiseEvents.Raise(new MessageReceved());

                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}
