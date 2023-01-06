using SCO.Contracts.DTOs;

namespace SCO.Contracts.Responses.Basket
{
    public class ItemsInBasketResponse
    {
        public IEnumerable<ItemDto> Items { get; set; }
    }
}
