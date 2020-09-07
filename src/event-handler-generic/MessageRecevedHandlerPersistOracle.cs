using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace event_handler_generic
{
    public class MessageRecevedHandlerPersistOracle : IHandler<MessageRecevedHandlerPersistOracle, MessageRecevedArgs>
    {
        private readonly ILogger<MessageRecevedHandlerPersistOracle> _logger;

        public MessageRecevedHandlerPersistOracle(ILogger<MessageRecevedHandlerPersistOracle> logger)
        {
            _logger = logger;
        }

        public void OnEvent(MessageRecevedArgs args) =>
            _logger.LogInformation($"Persist Oracle Handler - Message: {args.Message.Description} - Occurred: {args.DateOccurred}");

        public Task OnEventAsync(MessageRecevedArgs args) =>
            Task.Run(() => _logger.LogInformation($"Persist Oracle Handler - Message: {args.Message.Description} - Occurred: {args.DateOccurred}"));
    }
}
