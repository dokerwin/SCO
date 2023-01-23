using SCO.PrinterService.Domain;
using SCO.PrinterService.Domain.Entities.Ticket;

namespace SCO.PrinterService.Domain;

public class FilePrinter : IPrinter
{
    public bool IsPrinterEnabled { get;set; }

    public async Task<bool> PrintAsync(Ticket ticket)
    {
        try
        {
            using StreamWriter file = new(string.Format("Ticket-{0}", ticket.Id), append: false);

            string tick= string.Format("{****0****}\n{1}\n{2}\n{3}", ticket.Header, ticket.Body, ticket.EFTSlip, ticket.Footer );

            await file.WriteLineAsync(tick);
        }
        catch(Exception ex)
        {

        }
        return true;
    }
}
