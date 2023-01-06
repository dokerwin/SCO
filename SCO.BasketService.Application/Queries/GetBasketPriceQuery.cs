using MediatR;
using SCO.Contracts.Responses.Basket;

namespace SCO.BasketService.Application.Queries;

public record GetBasketPriceQuery() : IRequest<BasketPriceResponse>;