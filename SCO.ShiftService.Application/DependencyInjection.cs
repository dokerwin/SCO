using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SCO.ShiftService.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //services.AddSingleton<IBasketLogic, BasketLogic>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}