using Microsoft.Extensions.Logging;
using SCO.PaymentService.Application.Configuration;
using SCO.PaymentService.Domain;
using SCO.PaymentService.Domain.Enums;
using SCO.PaymentService.Domain.EPSPaymentRequests;
using SCO.PaymentService.Domain.PaymentResponses;
using SCO.PaymentService.Domain.ValueObjects;
using System.Text;
using System.Text.Json;

namespace SCO.PaymentService.Application;

public class PaymentLogic : IPaymentLogic
{
    private readonly PaymentConfiguration _paymentConfiguration;

    private readonly ILogger<PaymentLogic> _logger;

    public PaymentLogic(PaymentConfiguration paymentConfiguration, ILogger<PaymentLogic> logger)
    {
        _paymentConfiguration = paymentConfiguration;
        _logger = logger;
    }

    public Task<CardPaymentResult> AbortPayment(Guid paymentId)
    {
        CardPaymentResult result = new CardPaymentResult()
        {
            PaymentId = paymentId,
            Result = (int)PaymentStatus.Aborted
        };
        return Task.FromResult(result);

    }
    public async Task<CardPaymentResult> ProcessPayment(Guid OrderID, decimal amount)
    {
        string paymentResponse = string.Empty;
        try
        {
            var json = JsonSerializer.Serialize(new CardPaymentRequest()
            {
                TotalAmount = amount,
                BatchId = "OP2143"
            });

            using (var client = new HttpClient() { Timeout = TimeSpan.FromSeconds(_paymentConfiguration.PaymentConfigurationData.Timeout) })
            {
                var response = await client.PostAsync(
                     _paymentConfiguration.PaymentConfigurationData.TerminalUrl,
                     new StringContent(json, Encoding.UTF8, "application/json"));
                paymentResponse = await response.Content.ReadAsStringAsync();

            }

            var cardPaymetResponse = JsonSerializer.Deserialize<CardPaymetResponse>(paymentResponse);

            if (cardPaymetResponse != null)
            {

                return await Task.FromResult(new CardPaymentResult()
                {
                    PaymentId = Guid.NewGuid(),
                    Result = cardPaymetResponse.Result == "Success" ? (int)PaymentStatus.Successed : (int)PaymentStatus.Failure,
                    CardPan = cardPaymetResponse.CardPan
                });
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }

        return await Task.FromResult(new CardPaymentResult() { Result = (int)PaymentStatus.Failure });
    }
}
