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
        optionsAction => optionsAction.UseSqlite(Configuration.GetConnectionString("SCOConnectionString")));
        return services;
    }
}
