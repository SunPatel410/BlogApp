using BA.Infrastructure.Data.Interfaces;
using BA.Infrastructure.Data.Interfaces.Helpers;
using BA.Infrastructure.Data.Repositories;
using BA.Infrastructure.Data.Repositories.Helpers;
using Ninject;

namespace BA.Infrastructure.Data.Plumbings
{
    public class DataPlumbings
    {
        public void Initialize(IKernel kernel)
        {
            kernel.Bind<IBlogRepository>().To<BlogRepository>();
            kernel.Bind<ICommentRepository>().To<CommentRepository>();
            kernel.Bind<ICategoryRepository>().To<CategoryRepository>();
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();   
        }
    }

}
