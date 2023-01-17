using SCO.Contracts.DTOs;

namespace SCO.Contracts.Responses;

public class ProductsByCategoryResponse
{
    public IEnumerable<ProductDto> Items { get; set; }
}
