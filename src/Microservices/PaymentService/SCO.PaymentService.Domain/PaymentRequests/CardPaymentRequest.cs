namespace SCO.PaymentService.Domain.EPSPaymentRequests;

public class CardPaymentRequest : PaymentRequest
{
	public CardPaymentRequest()
	{
        PaymentType = Enums.PaymentType.CreditCard;
    }
}
