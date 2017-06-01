using System.Data.Entity.ModelConfiguration;
using BA.Domains;

namespace BA.Infrastructure.Data.Mappings
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            HasKey(c => c.Id);

            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(20);

            Property(c => c.CategoryDescription)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}
