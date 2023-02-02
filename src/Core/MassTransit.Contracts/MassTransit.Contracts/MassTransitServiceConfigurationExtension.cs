using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransit.Contracts;

public static class MassTransitServiceConfigurationExtension
{
    public static void Configure (this IServiceCollection services,
        Action<MassTransitConfiguration> configuration, string serviceName)
    {
        var transitConfiguration = new MassTransitConfiguration();
        if(configuration == null)
        {
            throw new ArgumentNullException (nameof(configuration));
        }
        configuration (transitConfiguration);

        if (string.IsNullOrWhiteSpace(serviceName))
        {
            throw new ArgumentNullException(nameof(serviceName));
        }

        transitConfiguration.ServiceName = serviceName;

        services.AddSingleton (transitConfiguration);
    }
}
