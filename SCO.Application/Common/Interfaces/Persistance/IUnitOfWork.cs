using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCO.Application.Common.Interfaces.Persistance;

public interface IUnitOfWork : IDisposable
{
    IShiftRepository          Shifts { get; }
  
    Task CompleteAsync();
}

