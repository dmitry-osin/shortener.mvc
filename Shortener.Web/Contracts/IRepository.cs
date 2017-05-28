using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Shortener.Web.Contracts
{
    public interface IRepository<TEntity>
    {
        TEntity Add(TEntity item);
        TEntity Attach(TEntity item);
        void AddRange(IEnumerable<TEntity> items);
        TEntity FindByKey(int id);
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] paths);
        void Update(TEntity item);
        void Remove(TEntity item);
        void RemoveRange(IEnumerable<TEntity> items);
        int Commit();
    }
}