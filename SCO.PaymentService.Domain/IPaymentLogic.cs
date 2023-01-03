using SCO.PaymentService.Domain.ValueObjects;

namespace SCO.PaymentService.Domain;

public interface IPaymentLogic
{
    Task<PaymentResult> ProcessPayment(Guid orderId, double amount);
    Task<PaymentResult> AbortPayment(Guid paymentId);
}
