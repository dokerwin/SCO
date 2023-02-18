﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SCO.PromotionService.EntityFramework.Persistence;

namespace SCO.PromotionService.EntityFramework.Seed;

public static class SCODbInitializerExtension
{
    public static IApplicationBuilder UseItToSeedSqlServer(this IApplicationBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app, nameof(app));

        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<SCOPromotionServiceContext>();
            SCOPromotionServiceDbInitializer.Initialize(context);
        }
        catch (Exception ex)
        {

        }

        return app;
    }
}
