using SCO.Contracts.DTOs;

namespace SCO.Contracts.Responses;
public class OrderResponse
{
    public IEnumerable<ItemDto> Items { get; set; }
}
