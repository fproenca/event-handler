using event_handler.Domain.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace event_handler.CrossCutting
{
    public class SendMessageHttpGateway : ISendMessageHttpGateway
    {
        private readonly ILogger<SendMessageHttpGateway> _logger;
        public SendMessageHttpGateway(ILogger<SendMessageHttpGateway> logger)
        {
            _logger = logger;
        }

        public async Task SendAsync(Message message)
        {
            await Task.Run(() =>
                    {
                        _logger.LogInformation($"Sending message to API, message {message.ToString()}");
                    });
        }
    }
}
