using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace event_handler.CrossCutting
{
    public interface IConsumeKafkaGateway
    {
        Task ConsumeAsync(CancellationToken cancellationToken);
    }
}
