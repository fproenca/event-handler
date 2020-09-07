using System;
using System.Collections.Generic;
using System.Text;

namespace event_handler_dotnet_framework
{
    public class MessageEventArgs : EventArgs
    {
        public DateTime DateOccurred { get; } = DateTime.Now;
        public Message Message { get; } = new Message();
    }
}
