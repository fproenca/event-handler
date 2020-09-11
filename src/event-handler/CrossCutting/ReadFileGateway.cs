using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace event_handler.CrossCutting
{
    public class ReadFileGateway : IReadFileGateway
    {
        public Task<string> ReadFileAsync(string path)
        {
            throw new NotImplementedException();
        }
    }
}
