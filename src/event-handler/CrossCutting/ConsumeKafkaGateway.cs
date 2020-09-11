using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace event_handler.CrossCutting
{
    public class ConsumeKafkaGateway : IConsumeKafkaGateway
    {
        public Task ConsumeAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
