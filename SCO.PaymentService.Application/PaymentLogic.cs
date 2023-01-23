using SCO.PaymentService.Application.Configuration;
using SCO.PaymentService.Domain;
using SCO.PaymentService.Domain.Enums;
using SCO.PaymentService.Domain.EPSPaymentRequests;
using SCO.PaymentService.Domain.ValueObjects;
using System.Text;
using System.Text.Json;

namespace SCO.PaymentService.Application;

public class PaymentLogic : IPaymentLogic
{
    private readonly PaymentConfiguration _paymentConfiguration;

    public PaymentLogic(PaymentConfiguration paymentConfiguration)
    {
        _paymentConfiguration = paymentConfiguration;
    }

    public Task<PaymentResult> AbortPayment(Guid paymentId)
    {
        PaymentResult result = new PaymentResult()
        {
            PaymentId = paymentId,
            Result = (int)PaymentStatus.Aborted
        };
        return Task.FromResult(result);

    }
    public async Task<PaymentResult> ProcessPayment(Guid OrderID, decimal amount)
    {

        Guid newPaymentID = Guid.NewGuid();

        PaymentResult result = new PaymentResult() 
        { 
            PaymentId = newPaymentID,
            Result = (int)PaymentStatus.Started
        };

        var json = JsonSerializer.Serialize(new CardPaymentRequest() 
            { 
               TotalAmount = amount 
            });

        using (var client = new HttpClient() { Timeout = TimeSpan.FromSeconds(_paymentConfiguration.PaymentConfigurationData.Timeout) })
        {
            var response = await client.PostAsync(
                 _paymentConfiguration.PaymentConfigurationData.TerminalUrl,
                 new StringContent(json, Encoding.UTF8, "application/json"));
        }

        return await Task.FromResult(result);
    }
}
