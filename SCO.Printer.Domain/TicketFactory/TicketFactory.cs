using SCO.PrinterService.Domain.Entities;
using SCO.PrinterService.Domain.Entities.Ticket;
using System.Text;

namespace SCO.PrinterService.Domain.Handlers;

public class TicketFactory : ITicketFactory
{
    private static readonly Lazy<TicketFactory> lazy =
           new Lazy<TicketFactory>(() => new TicketFactory());

    public static TicketFactory Instance { get { return lazy.Value; } }

    private TicketFactory()
    {
    }

    public Ticket GenerateTicket(RawTicket rawTicket)
    {

        Ticket ticket = new Ticket();

        StringBuilder sb = new StringBuilder();
        foreach (var rawItem in rawTicket.RawItems)
        {
            sb.AppendFormat("{0} {1} {2}",
                rawItem.ItemName,
                rawItem.Quantity ,
                rawItem.UnitPrice * rawItem.Quantity);
        }
        
        Header header = new Header()
        {
            Data = rawTicket.ShopData.ShopName
        };

        Body body = new Body()
        {
            Data = sb.ToString()
        };


        Footer footer = new Footer()
        {
            Data = rawTicket.ShopData.ShopAddress
        };

        ticket.SetHeader(header);
        ticket.SetBody(body);
        ticket.SetFooter(footer);

        return ticket;
    }

}
