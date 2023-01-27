using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SCO.BasketService.EntityFramework.Persistence;

namespace SCO.BasketService.EntityFramework;

public static class DependencyInjection
{
    public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration Configuration)
    {
        services.AddDbContext<SCOBasketServiceContext>(
        optionsAction => optionsAction.UseSqlite(Configuration.GetConnectionString("SCO_BasketService_ConnectionString"),
        x => x.MigrationsAssembly("SCO.EntityFramework.DbMigrations")));
        return services;
    }
}
