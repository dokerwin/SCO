using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SCO.PromotionService.EntityFramework.Persistence;

namespace SCO.PromotionService.EntityFramework;

public static class DependencyInjection
{
    public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration Configuration)
    {
        services.AddDbContext<SCOPromotionServiceContext>(
        optionsAction => optionsAction.UseSqlite(Configuration.GetConnectionString("SCO_PromotionService_ConnectionString"),
        x => x.MigrationsAssembly("SCO.EntityFramework.DbMigrations")));
        return services;
    }
}
