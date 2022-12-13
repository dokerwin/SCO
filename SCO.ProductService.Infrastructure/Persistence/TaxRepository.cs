using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SCO.ProductService.Application.Common.Interfaces.Persistance;
using SCO.ProductService.Domain.Entities;
using SCO.ProductService.EntityFramework.Persistence;

namespace SCO.ProductService.Infrastructure.Persitence;

public class TaxRepository : Repository<Tax>, ITaxRepository
{
    public TaxRepository(SCOProductContext context, ILogger logger) : base(context, logger) { }

    public override async Task<bool> Upsert(Tax entity)
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
            _logger.LogError(ex, "{Repo} Upsert function error", typeof(TaxRepository));
            return false;
        }
    }
}