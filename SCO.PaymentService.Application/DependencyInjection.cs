using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SCO.PaymentService.Domain;
using System.Reflection;
using MassTransit;
using SCO.PaymentService.Application.MassTransit;

namespace SCO.PaymentService.Application;
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
                    configurator.Username("myuser");
                    configurator.Password("mypassword");
                });
                c.ConfigureEndpoints(context, SnakeCaseEndpointNameFormatter.Instance);
            }));

            config.AddConsumer<StartPaymentConsumer>();
        });
        return services;
    }
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration Configuration)
    {
        services.AddMassTransit(Configuration);
        services.AddScoped<IPaymentLogic, PaymentLogic>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}