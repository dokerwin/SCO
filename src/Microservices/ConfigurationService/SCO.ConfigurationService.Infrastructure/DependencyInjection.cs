using Microsoft.Extensions.DependencyInjection;
using SCO.ConfigurationService.Infrastructure.Respositories;

namespace SCO.ConfigurationService.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddRepositorises();
        return services;
    }

    private static IServiceCollection AddRepositorises(this IServiceCollection services)
    {
        services.AddSingleton<PaymentSettingsRepository>();
        services.AddSingleton<ShopSettingsRepository>();
        services.AddSingleton<PrinterSettingsRepository>();
        return services;
    }
}