using MediatR;
using SCO.ProductService.Application.DTOs.Read.ProductDTOs;

namespace SCO.ProductService.Application.Queries;

public record GetProductsByNameQuery(ProductDto ProductDto) : IRequest<IEnumerable<ProductDto>>;
