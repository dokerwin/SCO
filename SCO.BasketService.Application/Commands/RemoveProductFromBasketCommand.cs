using MediatR;

namespace SCO.BasketService.Application.Commands;

public record RemoveProductFromBasketCommand(Guid ProductId) : IRequest;

