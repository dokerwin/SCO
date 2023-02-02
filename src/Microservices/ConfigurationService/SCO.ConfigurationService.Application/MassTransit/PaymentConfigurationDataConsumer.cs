using AutoMapper;
using MassTransit;
using Microsoft.Extensions.Logging;
using SCO.ConfigurationService.Infrastructure.Respositories;
using SCO.Contracts.Requests.Configuration;
using SCO.Contracts.Responses.Configuration;

namespace SCO.ConfigurationService.Application.MassTransit;

public class PaymentConfigurationDataConsumer : IConsumer<PaymentConfigurationRequest>
{
    private readonly PaymentSettingsRepository _paymentSettingsRepository;
    private readonly ILogger<PaymentConfigurationDataConsumer> _logger;
    public PaymentConfigurationDataConsumer(PaymentSettingsRepository paymentSettingsRepository,
        ILogger<PaymentConfigurationDataConsumer> logger )
    {
        _paymentSettingsRepository = paymentSettingsRepository;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<PaymentConfigurationRequest> context)
    {
        try
        {
            await context.RespondAsync(new PaymentConfigurationResponse(_paymentSettingsRepository.TerminalUrl,
                _paymentSettingsRepository.Timeout));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
    }
}
