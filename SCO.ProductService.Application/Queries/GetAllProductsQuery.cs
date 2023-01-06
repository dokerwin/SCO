using MediatR;
using SCO.ProductService.Application.DTOs.Read.ProductDTOs;

namespace SCO.ProductService.Application.Queries;

public record GetAllProductsQuery() : IRequest<IEnumerable<ProductDto>>;
