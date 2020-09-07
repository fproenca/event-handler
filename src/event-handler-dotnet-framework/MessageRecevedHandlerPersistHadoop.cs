using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace event_handler_dotnet_framework
{
    public class MessageRecevedHandlerPersistHadoop
    {
        private readonly ILogger<MessageRecevedHandlerPersistHadoop> _logger;

        public MessageRecevedHandlerPersistHadoop(ILogger<MessageRecevedHandlerPersistHadoop> logger)
        {
            _logger = logger;
        }

        public void OnMessageReceved(object sender, MessageEventArgs e)
        {
            _logger.LogInformation($"Persist Hadoop Handler - Message: {e.Message.Description} - Occurred: {e.DateOccurred}");
        }
    }
}
