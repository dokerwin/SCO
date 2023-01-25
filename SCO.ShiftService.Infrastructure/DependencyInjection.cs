using Microsoft.Extensions.DependencyInjection;
using SCO.ShiftService.Application.Common.Interfaces.Persistance;
using SCO.ShiftService.Infrastructure.Persitence;

namespace SCO.ShiftService.Infrastructure;
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
        services.AddScoped<IUnitOfWork,                 UnitOfWork>();
        services.AddScoped<IShiftRepository,            ShiftRepository>();
        return services;
    }
}