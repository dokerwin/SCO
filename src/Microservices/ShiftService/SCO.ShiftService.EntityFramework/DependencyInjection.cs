using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SCO.ShiftService.EntityFramework.Persistence;

namespace SCO.ShiftService.EntityFramework;

public static class DependencyInjection
{
    public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration Configuration)
    {
        services.AddDbContext<SCOShiftContext>(
        optionsAction => optionsAction.UseSqlite(Configuration.GetConnectionString("SCO_Shiftservice_ConnectionString")));
        return services;
    }
}
