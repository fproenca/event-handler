using event_handler.Events;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace event_handler.Handlers
{
    public class MessageRecevedHandlerPersistOracle : IEventHandler<MessageReceved>
    {
        private readonly ILogger<MessageRecevedHandlerPersistOracle> _logger;

        public MessageRecevedHandlerPersistOracle(ILogger<MessageRecevedHandlerPersistOracle> logger)
        {
            _logger = logger;
        }

        public void Handler(MessageReceved args)
        {
            _logger.LogInformation($"Persist Oracle, Event Occurred: {args.DateOccurred}");
        }

        public async Task HandlerAsync(MessageReceved args)
        {
            Task.Run(() => _logger.LogInformation($"Send SMS, Event Occurred: {args.DateOccurred}"));
        }
    }
}
