using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SCO.ProductService.Application.Common.Interfaces.Persistance;
using SCO.ProductService.Domain.Entities;
using SCO.ProductService.EntityFramework.Persistence;

namespace SCO.ProductService.Infrastructure.Persitence;

public class ProductOwnerRepository : Repository<ProductOwner>, IProductOwnerRepository
{
    public ProductOwnerRepository(SCOProductContext context, ILogger<ProductOwnerRepository> logger) : base(context, logger) { }

    public override async Task<bool> Upsert(ProductOwner entity)
    {
        try
        {
            var existingRole = await _dbSet.Where(x => x.Id == entity.Id)
                                                .FirstOrDefaultAsync();
            if (existingRole == null)
                return await Add(entity);

            existingRole.Name = entity.Name;

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repo} Upsert function error", typeof(ProductOwnerRepository));
            return false;
        }
    }

    public override async Task<bool> Delete(Guid id)
    {
        try
        {
            var exist = await _dbSet.Where(x => x.Id == id)
                                    .FirstOrDefaultAsync();

            if (exist == null) return false;

            _dbSet.Remove(exist);

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repo} Delete function error", typeof(ProductOwnerRepository));
            return false;
        }
    }
}

