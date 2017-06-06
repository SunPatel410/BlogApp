using BA.Domains;
using System.Data.Entity.ModelConfiguration;

namespace BA.Infrastructure.Data.Mappings
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        //public UserMap()
        //{
        //    HasKey(u => u.Id);

        //    Property(u => u.FirstName)
        //        .HasMaxLength(20);

        //    Property(u => u.LastName)
        //        .HasMaxLength(20);

        //    Property(u => u.Email)
        //        .IsRequired()
        //        .HasMaxLength(30);

        //    Property(u => u.Password)
        //        .IsRequired()
        //        .HasMaxLength(8);
        //}
    }
}
