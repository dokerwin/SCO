using Microsoft.Extensions.Logging;
using SCO.Application.Common.Interfaces.Persistance;
using SCO.EntityFramework.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCO.Infrastructure.Persitence;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly SCOContext _context;
    private readonly ILogger _logger;

   
    public IShiftRepository Shifts { get; private set; }
   
    public UnitOfWork(SCOContext context,
        ILoggerFactory loggerFactory, IShiftRepository shiftRepository
       
        )
    {
        _context = context;
        _logger = loggerFactory.CreateLogger("logs");

        Shifts = shiftRepository;
        
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }

}
