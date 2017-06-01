using BA.Domains;
using BA.Infrastructure.Data.Context;
using BA.Infrastructure.Data.Interfaces;
using BA.Infrastructure.Data.Repositories.Helpers;

namespace BA.Infrastructure.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(BlogDbContext context) : base(context)
        {
        }
    }
}