using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SCO.Identity.Aplications.Authentication.Authenticators;
using SCO.Identity.Aplications.Authentication.TokenGenerators;
using SCO.Identity.Aplications.Authentication.TokenValidators;
using SCO.Identity.Application.Authentication.Models;
using SCO.Identity.Domain.Entities.Employees;
using System.Reflection;
using System.Text;



namespace SCO.Identity.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddAplication(this IServiceCollection services, IConfiguration _configuration )
    {
        AuthenticationConfiguration authenticationConfiguration = new AuthenticationConfiguration();
        _configuration.Bind("Authentication", authenticationConfiguration);

        services.AddSingleton(authenticationConfiguration);
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o =>
        {
            o.TokenValidationParameters = new TokenValidationParameters()
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationConfiguration.AccessTokenSecret)),
                ValidIssuer = authenticationConfiguration.Issuer,
                ValidAudience = authenticationConfiguration.Audience,
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ClockSkew = TimeSpan.Zero
            };
        });
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddScoped<IPasswordHasher<Cashier>, PasswordHasher<Cashier>>();

        services.AddSingleton<AccessTokenGenerator>();
        services.AddSingleton<RefreshTokenGenerator>();
        services.AddSingleton<RefreshTokenValidator>();
        services.AddSingleton<TokenGenerator>();
        services.AddScoped<IAuthenticator, Authenticator>();
        services.AddScoped<IRefreshTokenValidator , RefreshTokenValidator>();
        services.AddMediatR(Assembly.GetExecutingAssembly());

       

        return services;
    }
}