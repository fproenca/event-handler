using event_handler.Domain.Model.Events;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace event_handler.Domain.Model.Handlers
{
    public class MessageRecevedHandlerSMS : IEventHandler<MessageReceived>
    {
        private readonly ILogger<MessageRecevedHandlerSMS> _logger;

        public MessageRecevedHandlerSMS(ILogger<MessageRecevedHandlerSMS> logger)
        {
            _logger = logger;
        }

        public async Task HandlerAsync(MessageReceived args)
        {
            Task.Run(() => _logger.LogInformation($"Send SMS, Event Occurred: {args.DateOccurred}"));
        }
    }
}
