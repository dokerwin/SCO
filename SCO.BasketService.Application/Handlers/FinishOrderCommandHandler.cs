using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SCO.BasketService.Application.Commands;
using SCO.BasketService.Domain;

namespace SCO.BasketService.Application.Handlers;

public class FinishOrderCommandHandler : AsyncRequestHandler<FinishOrderCommand>
{

    private readonly IMapper _mapper;
    private readonly IBasketLogic _basketLogic;
    private readonly ILogger<FinishOrderCommandHandler> _logger;

    public FinishOrderCommandHandler(IMapper mapper, IBasketLogic basketLogic, ILogger<FinishOrderCommandHandler> logger)
    {
        _mapper = mapper;
        _basketLogic = basketLogic;
        _logger = logger;
    }

    protected override Task Handle(FinishOrderCommand request, CancellationToken cancellationToken)
    {
        _basketLogic.CloseOrder();
        return Task.CompletedTask; 
    }
}
