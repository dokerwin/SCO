using SCO.Contracts.DTOs;

namespace SCO.Application.Queries;

public interface IBasketQueryService
{
    public IEnumerable<ItemDto> GetAllProducts();
    public decimal GetBasketPrice();
}
