using BA.Domains;

namespace BA.Services.Dtos
{
    public class LikeDto
    {
        public int Id { get; set; }
        public ApplicationUser Users { get; set; }

        public LikeDto()
        {
            
        }

        public LikeDto(int id, ApplicationUser user)
        {
            Id = id;
            Users = user;
        }
    }
}
