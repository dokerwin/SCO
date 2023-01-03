using Microsoft.IdentityModel.Tokens;
using SCO.Identity.Application.Common;
using SCO.Identity.Application.Common.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SCO.Identity.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly AuthenticationSettings _authentication;
        public JwtTokenGenerator(AuthenticationSettings authentication)
        {
            _authentication = authentication;
        }   
        public string GenerateToken(Guid userId, string firstName, string lastName, string rolename)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Name, $"{ firstName }{lastName}"),
                new Claim(ClaimTypes.Role, $"{ rolename}"),
               // new Claim("DateOfBirth", searchUser.DateOfBirth.Value.ToString("yyyy-MM-dd")),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_authentication.JwtKey));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.Now.AddDays(_authentication.JwtExpireDays);

            var token = new JwtSecurityToken(_authentication.JwtIssuer, _authentication.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }
    }
}
