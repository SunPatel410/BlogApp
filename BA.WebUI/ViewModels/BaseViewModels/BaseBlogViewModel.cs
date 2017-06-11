using System;

namespace BA.WebUI.ViewModels.BaseViewModels
{
    public abstract class BaseBlogViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public DateTime PostedDate { get; set; }
        public int LikeCount { get; set; }
    }
}