using Microsoft.Extensions.DependencyInjection;
using SCO.Identity.Application.Common.Interfaces;
using SCO.Identity.Application.Common.Interfaces.Persistance;
using SCO.Identity.Infrastructure.Authentication;
using SCO.Identity.Infrastructure.Persitence;

namespace SCO.Identity.Infrastructure;
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
        services.AddScoped<ICashierRepository,          CashierRepository>();
        services.AddScoped<IRoleRepository,             RoleRepository>();
        services.AddScoped<IRefreshTokenRepository,     RefreshTokenRepository>();

        return services;
    }
}