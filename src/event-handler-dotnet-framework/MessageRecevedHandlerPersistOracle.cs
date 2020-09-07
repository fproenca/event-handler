using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace event_handler_dotnet_framework
{
    public class MessageRecevedHandlerPersistOracle
    {
        private readonly ILogger<MessageRecevedHandlerPersistOracle> _logger;

        public MessageRecevedHandlerPersistOracle(ILogger<MessageRecevedHandlerPersistOracle> logger)
        {
            _logger = logger;
        }

        public void OnMessageReceved(object sender, MessageEventArgs e)
        {
            _logger.LogInformation($"Persist Oracle Handler - Message: {e.Message.Description} - Occurred: {e.DateOccurred}");
        }
    }
}
