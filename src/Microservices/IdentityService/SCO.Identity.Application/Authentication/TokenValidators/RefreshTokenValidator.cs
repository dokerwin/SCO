﻿using Microsoft.IdentityModel.Tokens;
using SCO.Identity.Application.Authentication.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace SCO.Identity.Aplications.Authentication.TokenValidators;

public class RefreshTokenValidator : IRefreshTokenValidator
{
    private readonly AuthenticationConfiguration _configuration;

    public RefreshTokenValidator(AuthenticationConfiguration configuration)
    {
        _configuration = configuration;
    }

    public bool Validate(string refreshToken)
    {
        TokenValidationParameters validationParameters = new TokenValidationParameters()
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.RefreshTokenSecret)),
            ValidIssuer = _configuration.Issuer,
            ValidAudience = _configuration.Audience,
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ClockSkew = TimeSpan.Zero
        };

        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

        try
        {
            tokenHandler.ValidateToken(refreshToken, validationParameters, out SecurityToken validatedToken);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
