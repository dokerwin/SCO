using Microsoft.Extensions.DependencyInjection;
using SCO.Application.Services.Authentication;

namespace SCO.Application;

public static class DependencyInjection 
{
 public static IServiceCollection AddAplication(this IServiceCollection services)
 {
     services.AddScoped<IAuthenticationService, AuthenticationService>();
     return services;
 }
}