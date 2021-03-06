﻿using System;
using System.Collections.Generic;

namespace BA.Services.Dtos
{
    public class BlogDto
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }
        public string Description { get; set; }
        public DateTime PostedDate { get; set; }
        public IList<CommentDto> Comments { get; set; }
        public IList<LikeDto> Likes { get; set; }

        public BlogDto()
        {
        }

        public BlogDto(int id, string user, string title, CategoryDto category, string description,
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
