using Microsoft.Extensions.DependencyInjection;
using SCO.BaskerService.Infrastructure.Persitence;
using SCO.BasketService.Application.Common.Interfaces.Persistance;
using SCO.BasketService.Infrastructure.Persitence;

namespace SCO.BasketService.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddRepositorises();
        return services;
    }

    private static IServiceCollection AddRepositorises(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        return services;
    }
}