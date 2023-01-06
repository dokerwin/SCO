using MediatR;
using SCO.ProductService.Application.DTOs.Read.ProductDTOs;

namespace SCO.ProductService.Application.Queries;

public record GetProductsByCategoryQuery(CategoryDto CategoryDto) : IRequest<IEnumerable<ProductDto>>;
