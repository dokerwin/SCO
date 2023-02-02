using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SCO.BasketService.Domain;
using System.Reflection;

namespace SCO.BasketService.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<IBasketLogic, BasketLogic>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}