using Microsoft.Extensions.Logging;
using SCO.Identity.Application.Common.Interfaces.Persistance;
using SCO.Identity.EntityFramework.Persistence;

namespace SCO.Identity.Infrastructure.Persitence;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly SCOIndentityContext _context;
    private readonly ILogger _logger;

    public ICashierRepository Cashiers { get; private set; }
    public IRoleRepository Roles { get; private set; }


    public UnitOfWork(SCOIndentityContext context,
        ILoggerFactory loggerFactory,
        ICashierRepository cashierRepository,
        IRoleRepository roleRepository)
    {
        _context = context;
        _logger = loggerFactory.CreateLogger("logs");
        Cashiers = cashierRepository;
        Roles = roleRepository;
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
