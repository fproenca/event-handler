using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using event_handler.CrossCutting;

namespace event_handler
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConsumeKafkaGateway _consumeKafkaGateway;

        public Worker(ILogger<Worker> logger, IConsumeKafkaGateway consumeKafkaGateway)
        {
            _logger = logger;
            _consumeKafkaGateway = consumeKafkaGateway;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _consumeKafkaGateway.ConsumeAsync(stoppingToken);
        }
    }
}
