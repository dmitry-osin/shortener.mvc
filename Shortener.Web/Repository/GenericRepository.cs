using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using Shortener.Web.Contracts;
using Shortener.Web.Infrastructure;

namespace Shortener.Web.Repository
{
    public abstract class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;
        // ReSharper disable once StaticMemberInGenericType
        private static readonly object SyncRoot = new object();
        private bool _disposed;

        protected GenericRepository(AppDbContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<TEntity>();
            EfConfigure();
        }

        #region [IGenericRepository Impl]

        public TEntity Add(TEntity item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            lock (SyncRoot)
            {
                return _dbSet.Add(item);
            }
        }

        public TEntity Attach(TEntity item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            lock (SyncRoot)
            {
                return _dbSet.Attach(item);
            }
        }

        public void AddRange(IEnumerable<TEntity> items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            lock (SyncRoot)
            {
                _dbSet.AddRange(items);
            }
        }

        public TEntity FindByKey(int id)
        {
            var item = Expression.Parameter(typeof(TEntity), "entity");
            var prop = Expression.Property(item, typeof(TEntity).Name + "Id");
            var value = Expression.Constant(id);
            var equal = Expression.Equal(prop, value);
            var lambda = Expression.Lambda<Func<TEntity, bool>>(equal, item);

            lock (SyncRoot)
            {
                return GetAsNoTrackingQueryable().SingleOrDefault(lambda);
            }
        }

        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            lock (SyncRoot)
            {
                return GetAsNoTrackingQueryable()
                    .Where(predicate).ToArray();
            }
        }

        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] paths)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            if (paths == null) throw new ArgumentNullException(nameof(paths));
            lock (SyncRoot)
            {
                var query = Include(paths);
                return query.Where(predicate).ToArray();
            }
        }

        public void Update(TEntity item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            lock (SyncRoot)
            {
                _dbSet.AddOrUpdate(item);
            }
        }

        public void Remove(TEntity item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            lock (SyncRoot)
            {
                _dbSet.Remove(item);
            }
        }

        public void RemoveRange(IEnumerable<TEntity> items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            lock (SyncRoot)
            {
                _dbSet.RemoveRange(items);
            }
        }

        public int Commit()
        {
            lock (SyncRoot)
            {
                return _dbContext.SaveChanges();
            }
        }

        #endregion

        #region [Queryable]

        protected IQueryable<TEntity> GetAsQueryable()
        {
            lock (SyncRoot)
            {
                return _dbSet;
            }
        }

        protected IQueryable<TEntity> GetAsNoTrackingQueryable()
        {
            lock (SyncRoot)
            {
                return _dbSet.AsNoTracking();
            }
        }

        #endregion

        #region [Methods]

        private void EfConfigure()
        {
            _dbContext.Configuration.AutoDetectChangesEnabled = false;
            _dbContext.Configuration.LazyLoadingEnabled = false;
            _dbContext.Configuration.ProxyCreationEnabled = false;
        }

        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] paths)
        {
            return paths
                .Aggregate(GetAsNoTrackingQueryable(),
                    (current, path) => current.Include(path));
        }

        #endregion

        #region [IDisposable Impl]

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext?.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~GenericRepository()
        {
            Dispose(false);
        }

        #endregion
    }
}