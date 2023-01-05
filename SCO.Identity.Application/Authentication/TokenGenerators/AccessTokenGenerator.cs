using SCO.Identity.Application.Authentication.Models;
using SCO.Identity.Domain.Entities.Employees;
using System.Security.Claims;

namespace SCO.Identity.Aplications.Authentication.TokenGenerators;

public class AccessTokenGenerator
{
    private readonly AuthenticationConfiguration _configuration;
    private readonly TokenGenerator _tokenGenerator;

    public AccessTokenGenerator(AuthenticationConfiguration configuration, TokenGenerator tokenGenerator)
    {
        _configuration = configuration;
        _tokenGenerator = tokenGenerator;
    }

    public AccessToken GenerateToken(Cashier user)
    {
        var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{ user.Firstname }{user.LastName}"),
                //new Claim(ClaimTypes.Role, $"{ user.Role.Name}"),
                new Claim("DateOfBirth", user.DateOfBirth.Value.ToString("yyyy-MM-dd")),
            };

        DateTime expirationTime = DateTime.UtcNow.AddMinutes(_configuration.AccessTokenExpirationMinutes);
        string value = _tokenGenerator.GenerateToken(
            _configuration.AccessTokenSecret,
            _configuration.Issuer,
            _configuration.Audience,
            expirationTime,
            claims);

        return new AccessToken()
        {
            Value = value,
            ExpirationTime = expirationTime
        };
    }
}
