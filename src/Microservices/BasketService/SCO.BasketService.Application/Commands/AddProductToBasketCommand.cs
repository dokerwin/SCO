using MediatR;
using SCO.Contracts.Responses.Basket;

namespace SCO.BasketService.Application.Commands;

public record AddProductToBasketCommand(Guid ProductID) : IRequest <AddProductToBasketResposne>;
