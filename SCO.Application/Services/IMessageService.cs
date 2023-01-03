using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCO.Application.Services
{
    public interface IMessageService
    {
        bool Enqueue(string message);
    }
}
