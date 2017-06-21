using BA.Domains;
using BA.Infrastructure.Data.Context;
using BA.Infrastructure.Data.Interfaces;
using BA.Infrastructure.Data.Repositories.Helpers;

namespace BA.Infrastructure.Data.Repositories
{
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        public BlogRepository(BlogDbContext context) : base(context)
        {
        }

    }
}
