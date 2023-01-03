using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SCO.Identity.EntityFramework.Persistence;

namespace SCO.Identity.EntityFramework;

public static class DependencyInjection
{
    public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration Configuration)
    {
        services.AddDbContext<SCOIndentityContext>(
        optionsAction => optionsAction.UseSqlServer(Configuration.GetConnectionString("SCOConnectionString"),
        x => x.MigrationsAssembly("SCO.Identity.EntityFramework.DbMigrations")));
        return services;
    }
}
