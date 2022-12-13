﻿using System.Linq.Expressions;

namespace SCO.ProductService.Application.Common.Interfaces.Persistance;

public interface IRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> All();
    Task<TEntity> GetById(Guid id);
    Task<bool> Add(TEntity entity);
    Task<bool> Delete(Guid id);
    Task<bool> Upsert(TEntity entity);
    Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
}

