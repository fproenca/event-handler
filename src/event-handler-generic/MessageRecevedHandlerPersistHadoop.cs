using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace event_handler_generic
{
    public class MessageRecevedHandlerPersistHadoop : IHandler<MessageRecevedHandlerPersistHadoop, MessageRecevedArgs>
    {
        private readonly ILogger<MessageRecevedHandlerPersistHadoop> _logger;

        public MessageRecevedHandlerPersistHadoop(ILogger<MessageRecevedHandlerPersistHadoop> logger)
        {
            _logger = logger;
        }

        public void OnEvent(MessageRecevedArgs args) =>
            _logger.LogInformation($"Persist Hadoop Handler - Message: {args.Message.Description} - Occurred: {args.DateOccurred}");

        public Task OnEventAsync(MessageRecevedArgs args) =>
            Task.Run(() => _logger.LogInformation($"Persist Hadoop Handler - Message: {args.Message.Description} - Occurred: {args.DateOccurred}"));
    }
}
