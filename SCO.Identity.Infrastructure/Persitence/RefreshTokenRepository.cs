using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SCO.Identity.Application.Common.Interfaces.Persistance;
using SCO.Identity.Domain;
using SCO.Identity.EntityFramework.Persistence;

namespace SCO.Identity.Infrastructure.Persitence;

public class RefreshTokenRepository : Repository<RefreshToken>, IRefreshTokenRepository
{
    public RefreshTokenRepository(SCOIndentityContext context, ILogger<RefreshTokenRepository> logger) : base(context, logger) { }

    public async Task<bool> DeleteAll(Guid userId)
    {
        try
        {
            var exist = await _dbSet.Where(x => x.UserId == userId)
                                    .FirstOrDefaultAsync();

            if (exist == null) return false;

            _dbSet.Remove(exist);

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repo} Delete function error", typeof(IRepository<RefreshTokenRepository>));
            return false;
        }
    }

    public async Task<RefreshToken> GetByToken(string token)
    {
        try
        {
            return await _dbSet.Where(t => t.Token == token).FirstOrDefaultAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repo} GetByToken function error", typeof(IRepository<RefreshTokenRepository>));
            return  new RefreshToken();
        }
        
    }

    public async Task<RefreshToken> Last()
    {
        try
        {
            return await _dbSet.Where(t => t.Id != Guid.Empty).FirstOrDefaultAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repo} Last function error", typeof(IRepository<RefreshTokenRepository>));
            return new RefreshToken();
        }
    }

}
