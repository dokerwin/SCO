using MediatR;
using SCO.Contracts.DTOs;

namespace SCO.ProductService.Application.Queries;

public record GetProductsByNameQuery(ProductDto ProductDto) : IRequest<IEnumerable<ProductDto>>;
