using System.Collections.Generic;

namespace BA.WebUI.ViewModels
{
    public class BlogListViewModel
    {
        public IEnumerable<BlogDetailViewModel> Blogs { get; set; }
    }
}
