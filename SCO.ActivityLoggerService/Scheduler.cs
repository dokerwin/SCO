using Microsoft.Extensions.Hosting;
using SCO.ActivityLoggerService;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SCO.ActivityLogger;

public class Scheduler : BackgroundService
{
    private IServiceProvider ServiceProvider;

    public Scheduler(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Timer timer = new Timer(new TimerCallback(PollEvents), stoppingToken, 2000, 2000);
        return Task.CompletedTask;
    }

    private void PollEvents(object state)
    {
        try
        {
            var logger = ServiceProvider.GetService(typeof(SCO.Interfaces.IActivityLogger)) as ActivityLoggerImpl;
            logger.ReceiveEvents();
        }
        catch
        {

        }
    }
}
