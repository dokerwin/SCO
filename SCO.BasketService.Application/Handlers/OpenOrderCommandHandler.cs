using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SCO.BasketService.Application.Commands;
using SCO.BasketService.Domain;

namespace SCO.BasketService.Application.Handlers;

public class OpenOrderCommandHandler : AsyncRequestHandler<OpenOrderCommand>
{

    private readonly IMapper _mapper;
    private readonly IBasketLogic _basketLogic;
    private readonly ILogger<OpenOrderCommandHandler> _logger;

    public OpenOrderCommandHandler(IMapper mapper, IBasketLogic basketLogic, ILogger<OpenOrderCommandHandler> logger)
    {
        _mapper = mapper;
        _basketLogic = basketLogic;
        _logger = logger;
    }

    protected override Task Handle(OpenOrderCommand request, CancellationToken cancellationToken)
    {
        _basketLogic.OpenOrder();
        return Task.CompletedTask;
    }
}
