using System.Collections.Generic;

namespace BA.WebUI.ViewModels.BlogViewModels
{
    public class CreateBlogViewModel
    {
        public int SelectedCategoryId { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}