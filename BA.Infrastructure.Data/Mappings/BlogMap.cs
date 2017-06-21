using BA.Domains;
using System.Data.Entity.ModelConfiguration;

namespace BA.Infrastructure.Data.Mappings
{
    public class BlogMap : EntityTypeConfiguration<Blog>
    {
        public BlogMap()
        {
            HasKey(b => b.Id);

            Property(g => g.CategoryId)
                .IsRequired();

            Property(b => b.User)
                .HasMaxLength(30);

            Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(25);

            HasRequired(b => b.Category)
                .WithMany();

            Property(b => b.Description)
                .IsRequired()
                .HasMaxLength(120);

            Property(b => b.PostedDate)
                .HasColumnType("datetime2");

            HasMany(p => p.Comments)
                .WithRequired();

            HasMany(p => p.Likes)
                .WithRequired()
                .WillCascadeOnDelete(false);
        }
    }
}
