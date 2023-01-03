using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SCO.Application.Common.Interfaces.Persistance;

public interface IRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> All();
    Task<TEntity> GetById(Guid id);
    Task<bool> Add(TEntity entity);
    Task<bool> Delete(Guid id);
    Task<bool> Upsert(TEntity entity);
    Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
}

