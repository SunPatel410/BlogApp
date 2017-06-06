using BA.Domains;
using System;
using System.Collections.Generic;

namespace BA.Services.Dtos
{
    public class BlogDto
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public string Title { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public DateTime PostedDate { get; set; }
        public IList<CommentDto> Comments { get; set; }
        public IList<LikeDto> Likes { get; set; }

        public BlogDto()
        {
        }

        public BlogDto(int id, ApplicationUser user, string title, Category category, string description,
            IList<CommentDto> comments, IList<LikeDto> likes)
        {
            Id = id;
            User = user;
            Title = title;
            Category = category;
            Description = description;
            PostedDate = DateTime.Now;
            Comments = comments;
            Likes = likes;
        }
    }
}
