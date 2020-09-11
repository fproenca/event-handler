using event_handler.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace event_handler.CrossCutting
{
    public interface ISendMessageHttpGateway
    {
        Task SendAsync(Message message);
    }
}
