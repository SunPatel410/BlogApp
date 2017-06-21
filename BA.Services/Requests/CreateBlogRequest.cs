using BA.Domains;

namespace BA.Services.Requests
{
    public class CreateBlogRequest
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ApplicationUser User { get; set; }
    }
}
