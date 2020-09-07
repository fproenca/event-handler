using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace event_handler_generic
{
    public interface IHandler<T, A>
    {
        Task OnEventAsync(A args);

        void OnEvent(A args);
    }
}
