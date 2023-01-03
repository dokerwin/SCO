

using SCO.PrinterService.Application.DTOs;

namespace SCO.PrinterService.Application.Commands;

public interface IPrintCommandService
{
    bool Print(TicketDto ticket);
}
