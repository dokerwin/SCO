using Microsoft.Extensions.DependencyInjection;
using SCO.ProductService.Application.Queries;

namespace SCO.ProductService.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IProductQueryService, ProductQueryService>();
      

        return services;
    }
}