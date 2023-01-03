using Microsoft.Extensions.DependencyInjection;
using SCO.ProductService.Application.Queries;
using System.Reflection;

namespace SCO.ProductService.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IProductQueryService, ProductQueryService>();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}