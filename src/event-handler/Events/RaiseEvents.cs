using event_handler.Handlers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace event_handler.Events
{
    public static class RaiseEvents
    {
        public static IServiceProvider Services { get; set; }

        public static async Task RaiseAsync<T>(T args) where T : IEvent
        {
            if (Services != null)
                foreach (var handler in Services.GetServices(typeof(IEventHandler<T>)))
                    ((IEventHandler<T>)handler).HandlerAsync(args);
        }
    }
}
