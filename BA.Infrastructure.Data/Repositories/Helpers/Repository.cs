using BA.Domains;
using BA.Infrastructure.Data.Context;
using BA.Infrastructure.Data.Interfaces.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace BA.Infrastructure.Data.Repositories.Helpers
{
    public abstract class Repository<T> : IRepository<T> where T : TEntity
    {
        private readonly IDbSet<T> _set;

        protected Repository(BlogDbContext context)
        {
            _set = context.Set<T>();
        }

        public T Get(int id)
        {
            return _set.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<T> Get()
        {
            return _set.AsNoTracking().ToList();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _set.AsNoTracking().Where(predicate);
        }

        public void Add(T entity)
        {
            _set.Add(entity);
        }

        public void Remove(T entity)
        {
            _set.Remove(entity);
        }
    }
}
