using BA.Domains;
using System;

namespace BA.WebUI.ViewModels
{
    public class BlogDetailViewModel
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public string Title { get;  set; }
        public Category Category { get;  set; }
        public string Description { get;  set; }
        public DateTime PostedDate { get;  set; }
        public int Likes { get; set; }
    }
}
