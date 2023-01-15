using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SCO.BasketService.Application.Commands;
using SCO.BasketService.Domain;

namespace SCO.BasketService.Application.Handlers;

public class AbortOrderCommandHandler : AsyncRequestHandler<AbortOrderCommand>
{

    private readonly IMapper _mapper;
    private readonly IBasketLogic _basketLogic;
    private readonly ILogger<AbortOrderCommandHandler> _logger;

    public AbortOrderCommandHandler(IMapper mapper, IBasketLogic basketLogic, ILogger<AbortOrderCommandHandler> logger)
    {
        _mapper = mapper;
        _basketLogic = basketLogic;
        _logger = logger;
    }

    protected override Task Handle(AbortOrderCommand request, CancellationToken cancellationToken)
    {
        _basketLogic.AbortOrder();
        return Task.CompletedTask;
    }
}
