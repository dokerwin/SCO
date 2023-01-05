namespace SCO.Identity.Aplications.Authentication.TokenValidators;

public interface IRefreshTokenValidator
{
    bool Validate(string refreshToken);
}