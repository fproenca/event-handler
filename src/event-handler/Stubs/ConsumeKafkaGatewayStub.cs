using event_handler.CrossCutting;
using event_handler.Domain.Model;
using event_handler.Domain.Model.DTO;
using event_handler.Domain.Model.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace event_handler.Stubs
{
    public class ConsumeKafkaGatewayStub : IConsumeKafkaGateway
    {
        public async Task ConsumeAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var message = new Message();
                var args = new MessageReceived(message);
                RaiseEvents.RaiseAsync(args);

                await Task.Delay(5000, cancellationToken);
            }
        }
    }
}
