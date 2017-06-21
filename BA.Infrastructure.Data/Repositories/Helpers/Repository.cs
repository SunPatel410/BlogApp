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
        protected BlogDbContext _context;
        protected readonly IDbSet<T> _dbset;


        protected Repository(BlogDbContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
        }

        public T Get(int id)
        {
            return _dbset.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<T> Get()
        {
            return _dbset.AsNoTracking().ToList();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _dbset.AsNoTracking().Where(predicate);
        }

        public void Add(T entity)
        {
            _dbset.Add(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(T entity)
        {
            _dbset.Remove(entity);
        }
    }
}
