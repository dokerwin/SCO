using SCO.PaymentService.Domain.Enteties;
using SCO.PaymentService.Domain.Enums;
using SCO.PaymentService.Domain.ValueObjects;

namespace SCO.PaymentService.Domain;

public class PaymentLogic : IPaymentLogic
{
    public Task<PaymentResult> AbortPayment(Guid paymentId)
    {
        PaymentResult result = new PaymentResult()
        {
            PaymentId = paymentId,
            Result = (int)PaymentStatus.Aborted
        };
        return Task.FromResult(result);

    }
    public Task<PaymentResult> ProcessPayment(Guid OrderID, double amount)
    {

        Guid newPaymentID = Guid.NewGuid();

        PaymentResult result = new PaymentResult() 
        { 
            PaymentId = newPaymentID,
            Result = (int)PaymentStatus.Started
        };

        return Task.FromResult(result);
    }
}
