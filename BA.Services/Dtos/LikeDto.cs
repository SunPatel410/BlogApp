using BA.Domains;

namespace BA.Services.Dtos
{
    public class LikeDto
    {
        public int Id { get; set; }
        public User Users { get; set; }

        public LikeDto()
        {
            
        }

        public LikeDto(int id, User user)
        {
            Id = id;
            Users = user;
        }
    }
}
