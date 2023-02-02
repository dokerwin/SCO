namespace SCO.PaymentService.Application.DTOs;

public class PaymentDto
{
    public  Guid Id { get; set; }
    public  DateTime PaymentDataTime { get; set; }
    public Guid MopId  { get; set; }
    public decimal Amount { get; set; }
    public int Status { get; set; }
}
