using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SCO.ProductService.EntityFramework.Persistence;

namespace SCO.ProductService.EntityFramework.Seed;

public static class SCODbInitializerExtension
{
    public static IApplicationBuilder UseItToSeedSqlServer(this IApplicationBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app, nameof(app));

        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<SCOProductContext>();
            SCODbInitializer.Initialize(context);
        }
        catch (Exception ex)
        {

        }

        return app;
    }
}
