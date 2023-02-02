
using SCO.PrinterService.Domain.Entities.Ticket;

namespace SCO.PrinterService.Domain.Entities;

public class RawTicket
{
    public Guid TicketId { get; set; }
    public DateTime TicketTime { get; set; }

    public ShopData ShopData { get; set; }
    public List<RawItem> RawItems { get; set; }
    public List<PaymentData> Payments { get; set; }

}
