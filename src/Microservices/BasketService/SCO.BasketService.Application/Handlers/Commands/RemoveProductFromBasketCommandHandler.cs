using AutoMapper;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using SCO.BasketService.Application.Commands;
using SCO.BasketService.Domain;
using SCO.BasketService.Domain.Entities;
using SCO.Contracts.Requests.Order;
using SCO.Contracts.Requests.Product;
using SCO.Contracts.Responses;

namespace SCO.BasketService.Application.Handlers.Commands;

public class RemoveProductFromBasketCommandHandler : IRequestHandler<RemoveProductFromBasketCommand>
{
    private readonly IBasketLogic _basketLogic;

    public RemoveProductFromBasketCommandHandler(IBasketLogic basketLogic)
    {
        _basketLogic = basketLogic;
    }

    public Task<Unit> Handle(RemoveProductFromBasketCommand request, CancellationToken cancellationToken)
    {
        _basketLogic.RemoveItemFromBasket(request.ProductId);

        return Task.FromResult(Unit.Value);
    }

}