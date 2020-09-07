using System;
using System.Collections.Generic;
using System.Text;

namespace event_handler_generic
{
    public interface IEventArgs<T> where T : new()
    {
        public DateTime DateOccurred { get => DateTime.Now; }
        public T Args { get => new T(); }
    }
}
