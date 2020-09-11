using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace event_handler.CrossCutting
{
    public interface IReadFileGateway
    {
        Task<string> ReadFileAsync(string path);
    }
}
