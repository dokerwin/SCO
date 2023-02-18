using Microsoft.Extensions.DependencyInjection;
using SCO.PromotionService.Application.Common.Interfaces.Persistance;
using SCO.PromotionService.Infrastructure.Persistence;
using SCO.PromotionService.Infrastructure.Persitence;

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
        services.AddScoped<IPromotionRepository, PromotionRepository>();
        return services;
    }
}