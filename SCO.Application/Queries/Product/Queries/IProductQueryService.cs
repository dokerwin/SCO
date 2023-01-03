using SCO.Contracts.DTOs;

namespace SCO.Application.Queries;

public interface IProductQueryService
{
    public ItemDto GetById(Guid id);
    public ItemDto GetByName(string name);
    public IEnumerable<ItemDto> GetByCategory(string name);
    public IEnumerable<ItemDto> GetAllProducts();
}
