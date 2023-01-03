namespace SCO.PaymentService.Application.DTOs;

public class PaymentDto
{
    public  Guid PaymentId { get; set; }
    public  DateTime PaymentDataTime { get; set; }
    public int MopId  { get; set; }
    public decimal Amount { get; set; }
    public int Status { get; set; }
}
