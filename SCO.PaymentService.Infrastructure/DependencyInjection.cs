using Microsoft.Extensions.DependencyInjection;
using SCO.PaymentService.Application.Common.Interfaces.Persistance;
using SCO.PaymentService.Infrastructure.Persitence;

namespace SCO.PaymentService.Infrastructure;
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
        services.AddScoped<IPaymentRepository, PaymentRepository>();

        return services;
    }
}