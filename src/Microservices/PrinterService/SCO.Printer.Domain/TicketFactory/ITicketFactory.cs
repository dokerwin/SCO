using SCO.PrinterService.Domain.Entities;
using SCO.PrinterService.Domain.Entities.Ticket;

namespace SCO.PrinterService.Domain.Handlers
{
    public interface ITicketFactory
    {
        Ticket GenerateTicket(RawTicket rawTicket);
    }
}