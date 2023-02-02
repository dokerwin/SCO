using SCO.Contracts.DTOs;

namespace SCO.PrinterService.Application.DTOs;

public class TicketDto
{
    public Guid OrderId { get; set; }
    public DateTime OrderedOn { get; set; }
    public IEnumerable<BasketItemDetailDto> ItemDetails { get; set; }

}
