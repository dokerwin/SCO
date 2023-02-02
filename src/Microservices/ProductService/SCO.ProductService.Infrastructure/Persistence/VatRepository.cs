using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SCO.ProductService.Application.Common.Interfaces.Persistance;
using SCO.ProductService.Domain.Entities;
using SCO.ProductService.EntityFramework.Persistence;

namespace SCO.ProductService.Infrastructure.Persitence;

public class VatRepository : Repository<Vat>, IVatRepository
{
    public VatRepository(SCOProductContext context, ILogger<VatRepository> logger) : base(context, logger)
    {
    }

    public override async Task<bool> Upsert(Vat entity)
    {
        try
        {
            var existingVat = await _dbSet.Where(x => x.Id == entity.Id)
                                              .FirstOrDefaultAsync();
            if (existingVat == null)
                return await Add(entity);

            existingVat.Name = entity.Name;
            existingVat.Percent = entity.Percent;


            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repo} Upsert function error", typeof(VatRepository));
            return false;
        }
    }
}