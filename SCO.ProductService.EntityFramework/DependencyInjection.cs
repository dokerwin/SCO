using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SCO.ProductService.EntityFramework.Persistence;

namespace SCO.ProductService.EntityFramework;

public static class DependencyInjection
{
    public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration Configuration)
    {
        services.AddDbContext<SCOProductContext>(
            optionsAction => optionsAction.UseSqlServer(Configuration.GetConnectionString("SCO_ProductService_ConnectionString")));
        return services;
    }
}
