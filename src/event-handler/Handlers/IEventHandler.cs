using event_handler.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace event_handler.Handlers
{
    public interface IEventHandler<E> where E : IEvent
    {
        Task HandlerAsync(E args);

        void Handler(E args);
    }
}
