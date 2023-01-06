using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using SCO.Application.Middleware;
using System.Reflection;

public static class DependencyInjection
{
    public static IServiceCollection AddAplication(this IServiceCollection services)
    {
        
        services.AddAutoMapper(Assembly.GetEntryAssembly());
        services.AddSingleton<IAuthorizationMiddlewareResultHandler, SampleAuthorizationMiddlewareResultHandler>();

        return services;
    }
}