using BA.Infrastructure.Data.Context;
using BA.Infrastructure.Data.Interfaces.Helpers;
using System;

namespace BA.Infrastructure.Data.Repositories.Helpers
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogDbContext _context;
        private bool _disposed;

        public UnitOfWork(BlogDbContext context)
        {
            _context = context;
        }

        public void Complete()
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
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

    }
}
