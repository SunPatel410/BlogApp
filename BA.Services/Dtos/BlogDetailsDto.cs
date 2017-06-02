using BA.Domains;
using System;

namespace BA.Services.Dtos
{
    public class BlogDetailsDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public DateTime PostedDate { get; set; }

        public BlogDetailsDto()
        {
            
        }

        public BlogDetailsDto(int id, string userName, string title, Category category, string description)
        {
            Id = id;
            UserName = userName;
            Title = title;
            Category = category;
            Description = description;
            PostedDate = DateTime.Now;
        }
    }
}
