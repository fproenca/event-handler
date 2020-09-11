using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace event_handler.Domain.Model
{
    public class SendMessageUserCase : IUserCase<SendMessageUserCase, string, Task>
    {
        public Task Execute(string imput)
        {
            throw new NotImplementedException();
        }
    }
}
