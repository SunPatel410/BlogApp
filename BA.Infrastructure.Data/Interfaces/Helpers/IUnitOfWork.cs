using System;

namespace BA.Infrastructure.Data.Interfaces.Helpers
{
    public interface IUnitOfWork : IDisposable
    {
        IBlogRepository Blogs { get; }
        ICategoryRepository Categories { get; }
        ICommentRepository Comments { get; }
        IUserRepository Users { get; }
        void Complete();
    }
}
