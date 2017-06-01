using BA.Infrastructure.Data.Context;
using BA.Infrastructure.Data.Interfaces.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace BA.Infrastructure.Data.Repositories.Helpers
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IDbSet<TEntity> _set;

        protected Repository(BlogDbContext context)
        {
            _set = context.Set<TEntity>();
        }

        public TEntity Get(int id)
        {
            return _set.Find(id);
        }

        public IEnumerable<TEntity> Get()
        {
            return _set.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _set.AsNoTracking().Where(predicate);
        }

        public void Add(TEntity entity)
        {
            _set.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            _set.Remove(entity);
        }
    }
}
