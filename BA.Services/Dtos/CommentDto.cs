using BA.Domains;
using System.Collections.Generic;

namespace BA.Services.Dtos
{
    public class CommentDto
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string CommentDescription { get; set; }
        public IList<LikeDto> Like { get; set; }

        public CommentDto()
        {
        }

        public CommentDto(int id, User user, string commentDescription, IList<LikeDto> like)
        {
            Id = id;
            User = user;
            CommentDescription = commentDescription;
            Like = like;
        }
    }
}
