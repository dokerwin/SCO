using Microsoft.Extensions.DependencyInjection;
using SCO.BasketService.Application.Queries;
using SCO.BasketService.Domain;
using System.Reflection;

namespace SCO.BasketService.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IBasketQueryService, BasketQueryService>();
        services.AddScoped<IBasketLogic, BasketLogic>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}