using SCO.BasketService.Domain.Entities;

namespace SCO.BasketService.Application.Common.Interfaces.Persistance;
public interface IOrderRepository : IRepository<Order>
{
    Task<Order> GetActualOrder();
}
