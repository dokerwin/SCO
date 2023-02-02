using MassTransit;
using SCO.Contracts.Requests.Configuration;
using SCO.Contracts.Responses.Configuration;
using SCO.PaymentService.Application.Common.Interfaces;
using System;

namespace SCO.PaymentService.Application.Configuration;

public class PaymentConfiguration 
{
   
    private readonly IBusControl _busControl;

    public PaymentConfigurationData PaymentConfigurationData;

    public PaymentConfiguration(IBusControl busControl)
    {
        _busControl = busControl;
        LoadPaymentConfiguration();
    }

    private async void LoadPaymentConfiguration()
    {
        var _configurationClient = _busControl.CreateRequestClient<PaymentConfigurationRequest>(TimeSpan.FromSeconds(180));
        var paymentConfiguration = await _configurationClient.GetResponse<PaymentConfigurationResponse>(
             new PaymentConfigurationRequest());

        PaymentConfigurationData = new()
        {
            TerminalUrl = paymentConfiguration.Message.TerminalUrl,
            Timeout = paymentConfiguration.Message.Timeout
        };
    }

}
