using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SCO.BasketService.EntityFramework.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCO.BasketService.EntityFramework;

public static class DependencyInjection
{
    public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration Configuration)
    {
        services.AddDbContext<SCOBasketServiceContext>(
        optionsAction => optionsAction.UseSqlServer(Configuration.GetConnectionString("SCO_BasketService_ConnectionString"),
        x => x.MigrationsAssembly("SCO.EntityFramework.DbMigrations")));
        return services;
    }
}
