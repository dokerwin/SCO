using MediatR;

namespace SCO.BasketService.Application.Commands;

public record AddProductToBasketCommand(Guid ProductID) : IRequest;
