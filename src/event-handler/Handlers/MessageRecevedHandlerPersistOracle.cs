using event_handler.Events;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace event_handler.Handlers
{
    public class MessageRecevedHandlerPersistOracle : IEventHandler<MessageReceived>
    {
        private readonly ILogger<MessageRecevedHandlerPersistOracle> _logger;

        public MessageRecevedHandlerPersistOracle(ILogger<MessageRecevedHandlerPersistOracle> logger)
        {
            _logger = logger;
        }


        public async Task HandlerAsync(MessageReceived args)
        {
            Task.Run(() => _logger.LogInformation($"Send Oracle, Event Occurred: {args.DateOccurred}"));
        }
    }
}
