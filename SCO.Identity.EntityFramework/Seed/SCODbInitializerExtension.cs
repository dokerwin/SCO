using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SCO.Identity.EntityFramework.Persistence;

namespace SCO.Identity.EntityFramework.Seed
{
    public static class SCODbInitializerExtension
    {
        public static IApplicationBuilder UseItToSeedDB(this IApplicationBuilder app)
        {
            ArgumentNullException.ThrowIfNull(app, nameof(app));

            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<SCOIndentityContext>();
                SCODbInitializer.Initialize(context);
            }
            catch (Exception ex)
            {

            }

            return app;
        }
    }
}
