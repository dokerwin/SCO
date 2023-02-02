using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SCO.ProductService.Application.Common.Interfaces.Persistance;
using SCO.ProductService.Domain.Entities;
using SCO.ProductService.EntityFramework.Persistence;
using SCO.ProductService.Infrastructure.Persitence;

namespace SCO.Infrastructure.Persitence
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly SCOProductContext _SCOcontext;
        public ProductRepository(SCOProductContext SCOcontext, ILogger<ProductRepository> logger) : base(SCOcontext, logger)
        {
            _SCOcontext = SCOcontext;
        }
        public IEnumerable<Product> GetTopSellingProducts(int count)
        {
            return _SCOcontext.Products.ToList();
        }

        public override async Task<bool> Upsert(Product entity)
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
                _logger.LogError(ex, "{Repo} Upsert function error", typeof(ProductRepository));
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
                _logger.LogError(ex, "{Repo} Delete function error", typeof(ProductRepository));
                return false;
            }
        }
    }
}
