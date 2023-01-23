using SCO.PaymentService.Domain.Enums;

namespace SCO.PaymentService.Domain.EPSPaymentRequests;

public abstract class PaymentRequest
{
    public decimal TotalAmount { get; set; }
    public PaymentType PaymentType { get; set; }
}

