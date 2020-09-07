using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace event_handler_dotnet_framework
{
    public class MessageRecevedEvent
    {
        private event EventHandler<MessageEventArgs> Event;

        public MessageRecevedEvent AddHandler(EventHandler<MessageEventArgs> eventHandler)
        {
            Event += eventHandler;
            return this;
        }

        public Task Raise(MessageEventArgs e) =>
            Task.Run(() => Event?.Invoke(this, e));
    }
}
