using SCO.Contracts.Identity;
using SCO.Identity.Aplications.Authentication.TokenGenerators;
using SCO.Identity.Application.Authentication.Models;
using SCO.Identity.Application.Common.Interfaces.Persistance;
using SCO.Identity.Domain;
using SCO.Identity.Domain.Entities.Employees;

namespace SCO.Identity.Aplications.Authentication.Authenticators;

public class Authenticator : IAuthenticator
{
    private readonly AccessTokenGenerator _accessTokenGenerator;
    private readonly RefreshTokenGenerator _refreshTokenGenerator;
    private readonly IUnitOfWork _unitOfWork;

    public Authenticator(AccessTokenGenerator accessTokenGenerator,
        RefreshTokenGenerator refreshTokenGenerator,
        IUnitOfWork unitOfWork)
    {
        _accessTokenGenerator = accessTokenGenerator;
        _refreshTokenGenerator = refreshTokenGenerator;
        _unitOfWork = unitOfWork;
    }

    public async Task<AuthenticatedUserResponse> Authenticate(Cashier user)
    {
        AccessToken accessToken = _accessTokenGenerator.GenerateToken(user);
        string refreshToken = _refreshTokenGenerator.GenerateToken();

        RefreshToken refreshTokenDTO = new RefreshToken()
        {
            Token = refreshToken,
            UserId = user.Id
        };
        await _unitOfWork.RefreshTokens.Add(refreshTokenDTO);

        await _unitOfWork.CompleteAsync();

        return new AuthenticatedUserResponse()
        {
            AccessToken = accessToken.Value,
            AccessTokenExpirationTime = accessToken.ExpirationTime,
            RefreshToken = refreshToken
        };
    }
}
