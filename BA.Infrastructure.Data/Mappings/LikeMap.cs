using BA.Domains;
using System.Data.Entity.ModelConfiguration;

namespace BA.Infrastructure.Data.Mappings
{
    public class LikeMap : EntityTypeConfiguration<Like>
    {
        public LikeMap()
        {
            HasKey(x => x.Id);

            HasRequired(c => c.User);
        }
    }
}
