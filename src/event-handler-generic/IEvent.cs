using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace event_handler_generic
{
    public interface IEvent<T, A>
    {
        Action<A> Event { get; }

        T AddHandler(Action<A> eventArgs);

        Task RaiseAsync(A args);

        void Raise(A args);
    }
}
