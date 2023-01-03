using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SCO.EntityFramework.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCO.EntityFramework
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<SCOContext>(
            optionsAction => optionsAction.UseSqlServer(Configuration.GetConnectionString("SCOConnectionString"),
            x => x.MigrationsAssembly("SCO.EntityFramework.DbMigrations")));
            return services;
        }
    }
}
