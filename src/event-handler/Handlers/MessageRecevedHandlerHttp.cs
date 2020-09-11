using event_handler.CrossCutting;
using event_handler.Events;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace event_handler.Handlers
{
    public class MessageRecevedHandlerHttp : IEventHandler<MessageReceived>
    {
        private readonly ILogger<MessageRecevedHandlerHttp> _logger;
        private readonly ISendMessageHttpGateway _sendMessageHttpGateway;

        public MessageRecevedHandlerHttp(ILogger<MessageRecevedHandlerHttp> logger, ISendMessageHttpGateway sendMessageHttpGateway)
        {
            _logger = logger;
            _sendMessageHttpGateway = sendMessageHttpGateway;
        }

        public async Task HandlerAsync(MessageReceived args)
        {
            await Task.Run(async () =>
                    {
                        _logger.LogInformation($"Sending message to API, Event Occurred: {args.DateOccurred}");
                        await _sendMessageHttpGateway.SendAsync(args.Message);
                    });
        }
    }
}
