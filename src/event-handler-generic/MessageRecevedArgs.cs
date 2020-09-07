using System;
using System.Collections.Generic;
using System.Text;

namespace event_handler_generic
{
    public class MessageRecevedArgs
    {
        public DateTime DateOccurred { get; } = DateTime.Now;
        public Message Message { get; } = new Message();
    }
}
