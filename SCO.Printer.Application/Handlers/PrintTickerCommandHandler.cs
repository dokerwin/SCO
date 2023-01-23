using AutoMapper;
using MassTransit;
using MediatR;
using SCO.Contracts.Requests.Configuration;
using SCO.Contracts.Responses.Configuration;
using SCO.Contracts.Responses.Printer;
using SCO.PrinterService.Domain;
using SCO.PrinterService.Domain.Entities;
using SCO.PrinterService.Domain.Entities.Ticket;
using SCO.PrinterService.Domain.Handlers;

namespace SCO.PrinterService.Application.Handlers;

public class PrintTickerCommandHandler: IRequestHandler<PrintTicketCommand, PrinterResponse>
{
    private readonly ITicketFactory _ticketFactory;
    private readonly IMapper _mapper;
    private readonly IBusControl _busControl;
    private readonly IPrinter _printer;

    public PrintTickerCommandHandler(IMapper mapper, IBusControl busControl, IPrinter printer, ITicketFactory ticketFactory)
    {
        _mapper = mapper;
        _busControl = busControl;
        _printer = printer;
        _ticketFactory = ticketFactory;
    }
    public async Task<PrinterResponse> Handle(PrintTicketCommand request, CancellationToken cancellationToken)
    {
        bool isTicketPrinted = false;


        var _productClient = _busControl.CreateRequestClient<ShopDataRequest>();

        var shopData = await _productClient.GetResponse<ShopDataResponse>(
                 new ShopDataRequest() { });

        var rawTicket = _mapper.Map<RawTicket>(request.Ticket);

        rawTicket.ShopData = new ShopData()
        {
            ShopName = shopData.Message.ShopName,
            ShopAddress = shopData.Message.ShopAddress
        };

        if (rawTicket != null)
        {
            isTicketPrinted  = await _printer.PrintAsync(_ticketFactory.GenerateTicket(rawTicket));
        }

        return await Task.FromResult(new PrinterResponse() { Status = isTicketPrinted ? 1 : 0 }) ;
    }
}
