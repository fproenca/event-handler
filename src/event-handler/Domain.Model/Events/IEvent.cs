using System;
using System.Collections.Generic;
using System.Text;

namespace event_handler.Domain.Model.Events
{
    public interface IEvent
    {
        DateTime DateOccurred { get; }
    }
}
