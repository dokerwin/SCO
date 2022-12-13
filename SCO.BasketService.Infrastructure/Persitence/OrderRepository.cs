using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SCO.BasketService.Application.Common.Interfaces.Persistance;
using SCO.BasketService.Domain.Entities;
using SCO.BasketService.EntityFramework.Persistence;

namespace SCO.BasketService.Infrastructure.Persitence;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(SCOBasketServiceContext context, ILogger logger) : base(context, logger)
    {
    }

    public async Task<Order> GetActualOrder()
    {
        try
        {
            var actualShift = await _dbSet.LastOrDefaultAsync();
            if (actualShift is not null)
                return actualShift;

            return  new Order();

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repo} Upsert function error", typeof(OrderRepository));
            return new Order();
        }
    }

    public override async Task<bool> Upsert(Order entity)
    {
        try
        {
            var existingRole = await _dbSet.Where(x => x.Id == entity.Id)
                                              .FirstOrDefaultAsync();
            if (existingRole == null)
                return await Add(entity);

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repo} Upsert function error", typeof(OrderRepository));
            return false;
        }
    }
}

