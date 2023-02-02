using Microsoft.Extensions.Logging;
using SCO.Identity.Application.Common.Interfaces.Persistance;
using SCO.Identity.EntityFramework.Persistence;

namespace SCO.Identity.Infrastructure.Persitence;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly SCOIndentityContext _context;
    public ICashierRepository Cashiers { get; private set; }
    public IRoleRepository Roles { get; private set; }
    public IRefreshTokenRepository RefreshTokens { get; private set; }


    public UnitOfWork(SCOIndentityContext context,
        ICashierRepository cashierRepository,
        IRoleRepository roleRepository,
        IRefreshTokenRepository refreshTokens)
    {
        _context = context;
        Cashiers = cashierRepository;
        Roles = roleRepository;
        RefreshTokens = refreshTokens;
    }

    public async Task CompleteAsync()
    {
        try 
        { 
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("dffdf");   
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
