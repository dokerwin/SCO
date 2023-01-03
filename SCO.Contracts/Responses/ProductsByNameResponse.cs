using SCO.Contracts.DTOs;

namespace SCO.Contracts.Responses;

public class ProductsResponse
{
    public IEnumerable<ItemDto> Items { get; set; }
}
