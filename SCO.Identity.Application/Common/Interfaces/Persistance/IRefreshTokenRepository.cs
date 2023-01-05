using SCO.Identity.Domain;

namespace SCO.Identity.Application.Common.Interfaces.Persistance;

public interface IRefreshTokenRepository :  IRepository<RefreshToken> 
{
    Task<RefreshToken> GetByToken(string token);

    Task Create(RefreshToken refreshToken);

    Task Delete(Guid id);

    Task DeleteAll(Guid userId);
}
