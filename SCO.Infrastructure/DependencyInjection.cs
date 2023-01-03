using Microsoft.Extensions.DependencyInjection;
using SCO.Application.Common.Interfaces;
using SCO.Application.Common.Interfaces.Persistance;
using SCO.Infrastructure.Persitence;

namespace SCO.Infrastructure;
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
        services.AddScoped<IShiftRepository,         ShiftRepository>();
              return services;
    }
}