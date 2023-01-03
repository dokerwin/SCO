using SCO.Contracts.DTOs;

namespace SCO.BasketService.Application.Queries
{
    public interface IBasketQueryService
    {
        public IEnumerable<ItemDto> GetAllProducts();
        decimal GetBasketPrice();
    }
}
