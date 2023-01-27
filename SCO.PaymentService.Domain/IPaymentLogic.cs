using SCO.PaymentService.Domain.ValueObjects;

namespace SCO.PaymentService.Domain;

public interface IPaymentLogic
{
    Task<CardPaymentResult> ProcessPayment(Guid orderId, decimal amount);
    Task<CardPaymentResult> AbortPayment(Guid paymentId);
}
