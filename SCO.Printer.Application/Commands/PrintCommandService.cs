using SCO.PrinterService.Application.DTOs;

namespace SCO.PrinterService.Application.Commands;

internal class PrintCommandService : IPrintCommandService
{
    public bool Print(TicketDto ticketDto)
    {
        return true;
    }
}
