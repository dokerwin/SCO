namespace SCO.PaymentService.Domain.PaymentResponses;

public class PaymentResponse
{
    public string Result { get; set; }
    public decimal Amount { get; set; }
    public DateTime? Date { get; set; }
}
