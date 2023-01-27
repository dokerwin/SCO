using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SCO.PaymentService.EntityFramework.Persistence;

namespace SCO.PaymentService.EntityFramework;

public static class DependencyInjection
{
    public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration Configuration)
    {
        services.AddDbContext<SCOPaymentContext>(
            optionsAction => optionsAction.UseSqlite(Configuration.GetConnectionString("SCO_PaymentService_ConnectionString")));
        return services;
    }
}
