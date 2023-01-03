using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SCO.Application.Common;
using SCO.Application.Queries;
using SCO.Application.Services;
using SCO.Application.Services.Authentication.Commands;
using SCO.Domain.Entities.Employees;
using System.Reflection;

public static class DependencyInjection
{
    public static IServiceCollection AddAplication(this IServiceCollection services, IConfiguration Configuration )
    {
        //var authenticationSettings = new AuthenticationSettings();
        //Configuration.GetSection("Authentication").Bind(authenticationSettings);
        //services.AddSingleton(authenticationSettings);
        //services.AddAuthentication(o =>
        //{
        //    o.DefaultAuthenticateScheme = "Bearer";
        //    o.DefaultScheme = "Bearer";
        //    o.DefaultChallengeScheme = "Bearer";
        //}).AddJwtBearer(cfg =>
        //{
        //    cfg.RequireHttpsMetadata = false;
        //    cfg.SaveToken = true;
        //    cfg.TokenValidationParameters = new TokenValidationParameters
        //    {
        //        ValidIssuer = authenticationSettings.JwtIssuer,
        //        ValidAudience = authenticationSettings.JwtIssuer,
        //        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
        //    };

        //});
        
        services.AddAutoMapper(Assembly.GetEntryAssembly());
        //services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
        //services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();
        //services.AddScoped<IPasswordHasher<Cashier>, PasswordHasher<Cashier>>();
        services.AddScoped<IProductQueryService, ProductQueryService>();

       

        //services.AddSingleton<IMessageService, MessageService>();

        return services;
    }
}