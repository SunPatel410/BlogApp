using BA.Infrastructure.Data.Context;
using BA.Infrastructure.Data.Interfaces;
using BA.Infrastructure.Data.Interfaces.Helpers;

namespace BA.Infrastructure.Data.Repositories.Helpers
{
    //use unit of work within my service. 
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogDbContext _context;

        public IBlogRepository Blogs { get; }
        public ICategoryRepository Categories { get; }
        public ICommentRepository Comments { get; }
        //public IUserRepository Users { get; }


        public UnitOfWork(BlogDbContext context)
        {
            _context = context;
            Blogs = new BlogRepository(_context);
            Categories = new CategoryRepository(_context);
            Comments = new CommentRepository(_context);
            //Users = new UserRepository(_context);
        }

        public void Complete()
        {
            if (_context.ChangeTracker.HasChanges())
                _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
