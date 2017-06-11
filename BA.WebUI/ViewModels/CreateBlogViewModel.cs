using BA.Domains;
using System.Collections.Generic;

namespace BA.WebUI.ViewModels
{
    public class CreateBlogViewModel
    {
        public int SelectedCategoryId { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}