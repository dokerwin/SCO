using MassTransit;
using MassTransit.ExtensionsDependencyInjectionIntegration;
using Microsoft.Extensions.DependencyInjection;

namespace MassTransit.Contracts;

public class MassTransitConfiguration
{
    public bool IsDebug { get; set; }

    public Action<IServiceCollectionBusConfigurator> Configuration { get; set; }

    public Action<IBusControl> BusControl { get; set; }

    public string ServiceName { get; set; }
}
