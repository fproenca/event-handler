using event_handler.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace event_handler.Events
{
    public class MessageReceived : IEvent
    {
        public MessageReceived(Message message)
        {
            Message = message;
        }

        public DateTime DateOccurred => DateTime.Now;

        public Message Message { get; }
    }
}
