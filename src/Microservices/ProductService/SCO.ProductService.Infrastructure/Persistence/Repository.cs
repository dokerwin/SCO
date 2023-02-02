using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SCO.ProductService.Application.Common.Interfaces.Persistance;
using SCO.ProductService.Domain.Entities.Base;
using System.Linq.Expressions;

namespace SCO.ProductService.Infrastructure.Persitence;

public class Repository<T> : IRepository<T> where T : EntityBase<Guid>
{
    protected readonly DbContext _context;
    public DbSet<T> _dbSet;
    public readonly ILogger<Repository<T>> _logger;

    public Repository(
        DbContext context,
        ILogger<Repository<T>> logger)
    {
        _context = context;
        _dbSet = context.Set<T>();
        _logger = logger;
    }

    public virtual async Task<T> GetById(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<bool> Add(T entity)
    {
        await _dbSet.AddAsync(entity);
        return true;
    }

    public virtual async Task<bool> Delete(Guid id)
    {
        try{
            var exist = await _dbSet.Where(x => x.Id == id)
                                    .FirstOrDefaultAsync();

            if (exist == null) return false;

            _dbSet.Remove(exist);

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repo} Delete function error", typeof(IRepository<T>));
            return false;
        }
    }

    public async Task<IEnumerable<T>> All()
    {
        try
        {
            return await _dbSet.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repo} All function error", typeof(IRepository<T>));
            return new List<T>();
        }
    }

    public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    public virtual Task<bool> Upsert(T entity)
    {
        throw new NotImplementedException();
    }

}

