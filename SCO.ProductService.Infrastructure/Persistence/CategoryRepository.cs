using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SCO.ProductService.Application.Common.Interfaces.Persistance;
using SCO.ProductService.Domain.Entities;
using SCO.ProductService.EntityFramework.Persistence;


namespace SCO.ProductService.Infrastructure.Persitence;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(SCOProductContext context, ILogger logger) : base(context, logger) { }

    public override async Task<bool> Upsert(Category entity)
    {
        try
        {
            var existingCategory = await _dbSet.Where(x => x.Id == entity.Id)
                                                .FirstOrDefaultAsync();
            if (existingCategory == null)
                return await Add(entity);

            existingCategory.Name = entity.Name;
            existingCategory.GategoryIdentifire = entity.GategoryIdentifire;

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repo} Upsert function error", typeof(CategoryRepository));
            return false;
        }
    }

}
