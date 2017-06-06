using BA.Domains;
using BA.Infrastructure.Data.Mappings;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace BA.Infrastructure.Data.Context
{
    public class BlogDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        //public DbSet<User> Users { get; set; }

        public BlogDbContext() : base("BlogDbContext")
        {
            Database.SetInitializer<BlogDbContext>(null);
            Configuration.AutoDetectChangesEnabled = false;
        }

        public static BlogDbContext Create()
        {
            return new BlogDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BlogMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new CommentMap());
            modelBuilder.Configurations.Add(new LikeMap());
            //modelBuilder.Configurations.Add(new UserMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
