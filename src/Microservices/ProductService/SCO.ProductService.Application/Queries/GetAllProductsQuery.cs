using MediatR;
using SCO.Contracts.DTOs;

namespace SCO.ProductService.Application.Queries;

public record GetAllProductsQuery() : IRequest<IEnumerable<ProductDto>>;
