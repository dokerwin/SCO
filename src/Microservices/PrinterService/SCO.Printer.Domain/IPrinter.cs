using SCO.PrinterService.Domain.Entities.Ticket;

namespace SCO.PrinterService.Domain;

public interface IPrinter
{
    bool IsPrinterEnabled { get; }
    Task<bool> PrintAsync(Ticket ticketDto);
}
