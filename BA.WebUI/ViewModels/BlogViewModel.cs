using System.Collections.Generic;
using BA.WebUI.ViewModels.BaseViewModels;

namespace BA.WebUI.ViewModels
{
    public class BlogViewModel : BaseBlogViewModel
    {
        public IEnumerable<CommentViewModel> Comments { get;  set; }
    }
}
