using BA.Services.Interfaces;
using BA.Services.Services;
using Ninject;

namespace BA.Services.Plumbings
{
    public class ServicesPlumbing
    {
        public void Initialize(IKernel kernel)
        {
            kernel.Bind<IBlogService>().To<BlogService>();
            kernel.Bind<ICategoryService>().To<CategoryService>();
            kernel.Bind<ICommentService>().To<CommentService>();

            new Infrastructure.Data.Plumbings.DataPlumbings().Initialize(kernel);
        }
    }
}
