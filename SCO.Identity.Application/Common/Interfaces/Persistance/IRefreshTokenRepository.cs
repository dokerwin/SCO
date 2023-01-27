using SCO.Identity.Domain;

namespace SCO.Identity.Application.Common.Interfaces.Persistance;

public interface IRefreshTokenRepository :  IRepository<RefreshToken> 
{
    Task<bool> DeleteAll(Guid userId);
    Task<RefreshToken> GetByToken(string token);

    Task<RefreshToken> Last();
}
