using SCO.ProductService.Application.DTOs;
using SCO.ProductService.Application.DTOs.Read.ProductDTOs;

namespace SCO.ProductService.Application.Queries;

public interface IProductQueryService
{
    public Task<ProductDto> GetById(Guid id);
    public Task<ProductDto> GetByName(string name);
    public Task<IEnumerable<ProductDto>> GetByCategory(string name);
    public Task<IEnumerable<ProductDto>> GetAllProducts();
}
