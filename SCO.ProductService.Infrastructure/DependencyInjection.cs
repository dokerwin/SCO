using Microsoft.Extensions.DependencyInjection;
using SCO.Infrastructure.Persitence;
using SCO.ProductService.Application.Common.Interfaces.Persistance;
using SCO.ProductService.Infrastructure.Persitence;

namespace SCO.ProductService.Infrastructure;
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
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductOwnerRepository, ProductOwnerRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ITaxRepository, TaxRepository>();
        services.AddScoped<IVatRepository, VatRepository>();

        return services;
    }
}