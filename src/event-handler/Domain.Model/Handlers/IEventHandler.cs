using event_handler.Domain.Model.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace event_handler.Domain.Model.Handlers
{
    public interface IEventHandler<E> where E : IEvent
    {
        Task HandlerAsync(E args);
    }
}
