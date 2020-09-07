using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace event_handler_generic
{
    public class MessageReceved : IEvent<MessageReceved, MessageRecevedArgs>
    {
        public Action<MessageRecevedArgs> Event { get; private set; }

        public MessageReceved AddHandler(Action<MessageRecevedArgs> eventArgs)
        {
            Event += eventArgs;
            return this;
        }

        public Task RaiseAsync(MessageRecevedArgs e) =>
            Task.Run(() => Event?.Invoke(e));

        public void Raise(MessageRecevedArgs e) => 
            Event?.Invoke(e);
    }
}
