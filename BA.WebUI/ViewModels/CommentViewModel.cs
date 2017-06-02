using BA.Domains;
using System.Collections.Generic;

namespace BA.WebUI.ViewModels
{
    public class CommentViewModel
    {
        public string CommentDescription { get;  set; }
        public IList<Like> Likes { get; set; }

        public CommentViewModel()
        {
            Likes = new List<Like>();
        }
    }
}
