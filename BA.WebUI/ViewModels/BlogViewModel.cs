using BA.Domains;
using System;
using System.Collections.Generic;

namespace BA.WebUI.ViewModels
{
    public class BlogViewModel
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public string Title { get;  set; }
        public Category Category { get;  set; }
        public string Description { get;  set; }
        public DateTime PostedDate { get;  set; }
        public IList<Comment> Comments { get;  set; }
        public int Likes { get; set; }
    }
}
