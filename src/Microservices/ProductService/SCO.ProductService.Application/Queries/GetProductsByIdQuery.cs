using MediatR;
using SCO.Contracts.DTOs;

namespace SCO.ProductService.Application.Queries;

public record GetProductsByIdQuery(Guid Id) : IRequest<ProductDto>;

