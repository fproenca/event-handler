using System;
using System.Collections.Generic;
using System.Text;

namespace event_handler.Events
{
    public class MessageReceved : IEvent
    {
        public DateTime DateOccurred => DateTime.Now;
    }
}
