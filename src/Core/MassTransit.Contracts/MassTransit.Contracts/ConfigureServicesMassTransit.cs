
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MassTransit.Contracts;

public static class ConfigureServicesMassTransit
{

    public static void ConfigureServices(
        IServiceCollection services,
        IConfiguration configuration,
        MassTransitConfiguration massTransitConfiguration)
    {

        if (massTransitConfiguration == null || massTransitConfiguration.IsDebug)
        {
            return;
        }

        var rabbitSection = configuration.GetSection("RabitServer");
        var url = rabbitSection.GetValue<string>("Url");
        var host = rabbitSection.GetValue<string>("Host");


        //services.AddMassTransit(x =>
        //{
        //    x.AddBus(busFactory =>
        //    {
        //        var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
        //        {
        //            cfg.Host($"rabbitmq://{url}/{host}", configurator =>
        //            {
        //                configurator.Username("guest");
        //                configurator.Password("guest");
        //            });
        //            cfg.ConfigureEndpoints(busFactory, SnakeCaseEndpointNameFormatter.Instance);
        //        });

        //        massTransitConfiguration.BusControl?.Invoke(bus);
        //        return bus;
        //    });

        //    massTransitConfiguration.Configuration?.Invoke(x);
        //    services.AddMassTransitHostedService();
        //});



        services.AddMassTransit(config =>
        {
            config.AddBus(context => Bus.Factory.CreateUsingRabbitMq(c =>
            {
                c.Host($"rabbitmq://{url}/{host}", configurator =>
                {
                    configurator.Username("myuser");
                    configurator.Password("mypassword");
                });
                c.ConfigureEndpoints(context, SnakeCaseEndpointNameFormatter.Instance);
            }));

            services.AddMassTransitHostedService();
            
            //massTransitConfiguration.Configuration?.Invoke(config);
        });
    }
}