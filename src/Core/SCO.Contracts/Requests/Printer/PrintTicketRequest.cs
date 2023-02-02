using SCO.PrinterService.Application.DTOs;

namespace SCO.Contracts.Requests.Printer;

public class PrintTicketRequest
{
    public TicketDto TicketDto { get; set; }
}
