using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SCO.Identity.Application.Common.Interfaces.Persistance;
using SCO.Identity.Domain;
using SCO.Identity.EntityFramework.Persistence;

namespace SCO.Identity.Infrastructure.Persitence;

public class RefreshTokenRepository : Repository<RefreshToken>, IRefreshTokenRepository
{
    public RefreshTokenRepository(SCOIndentityContext context, ILogger<RefreshTokenRepository> logger) : base(context, logger) { }

    public Task Create(RefreshToken refreshToken)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAll(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<RefreshToken> GetByToken(string token)
    {
        throw new NotImplementedException();
    }

    Task IRefreshTokenRepository.Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}
