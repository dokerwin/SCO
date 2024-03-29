﻿using MediatR;
using SCO.Contracts.Responses.Basket;

namespace SCO.BasketService.Application.Queries;

public record GetBasketDetailsQuery : IRequest<BasketDetailsResponse>;
