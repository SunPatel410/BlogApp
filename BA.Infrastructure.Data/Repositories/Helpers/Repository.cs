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
    public abstract class Repository<T> : IRepository<T>, IDisposable where T : TEntity
    {
        protected BlogDbContext _context;
        protected readonly IDbSet<T> _dbset;
        protected bool _disposed;

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
            Save();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            Save();
        }

        public void Remove(T entity)
        {
            _dbset.Remove(entity);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _context.Dispose();
            _disposed = true;
        }
    }
}
