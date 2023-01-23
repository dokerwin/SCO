namespace SCO.PrinterService.Domain.Entities;

public class PaymentData
{
    public string CardPan { get; set; }
    public DateTime PaymentTime { get; set; }
    public decimal PaymentAmount { get; set; }

}