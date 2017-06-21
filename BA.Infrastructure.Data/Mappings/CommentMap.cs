using BA.Domains;
using System.Data.Entity.ModelConfiguration;

namespace BA.Infrastructure.Data.Mappings
{
    public class CommentMap : EntityTypeConfiguration<Comment>
    {
        public CommentMap()
        {
            HasKey(c => c.Id);

            Property(c => c.User)
                .HasMaxLength(30);

            Property(c => c.CommentDescription)
                .IsRequired()
                .HasMaxLength(50);

            HasMany(c => c.Likes)
                .WithRequired()
                .WillCascadeOnDelete(false);
        }
    }
}
