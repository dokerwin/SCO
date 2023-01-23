using MassTransit;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SCO.ConfigurationService.Application.MassTransit;
using System.Reflection;

namespace SCO.ConfigurationService.Application;
public static class DependencyInjection
{

    public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration Configuration)
    {

        var rabbitSection = Configuration.GetSection("RabitServer");
        var url = rabbitSection.GetValue<string>("Url");
        var host = rabbitSection.GetValue<string>("Host");

        services.AddMassTransit(config =>
        {
            config.AddBus(context => Bus.Factory.CreateUsingRabbitMq(c =>
            {
                c.Host($"rabbitmq://{url}/{host}", configurator =>
                {
                    configurator.Username("guest");
                    configurator.Password("guest");
                });
                c.ConfigureEndpoints(context, SnakeCaseEndpointNameFormatter.Instance);
            }));

            config.AddConsumer<ShopDataRequestConsumer>();
        });
        return services;
    }
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration Configuration)
    {
        services.AddMassTransit(Configuration);
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}