namespace BA.Services.Requests
{
    public class CreateBlogRequest
    {
        public string User { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
