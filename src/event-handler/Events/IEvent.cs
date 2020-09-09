using System;
using System.Collections.Generic;
using System.Text;

namespace event_handler.Events
{
    public interface IEvent
    {
        DateTime DateOccurred { get; }
    }
}
