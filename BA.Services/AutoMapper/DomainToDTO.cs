using AutoMapper;
using BA.Domains;
using BA.Services.Dtos;
using BA.Services.Requests;

namespace BA.Services.AutoMapper
{
    public class DomainToDto : Profile
    {
        public DomainToDto()
        {
            CreateMap<Blog, BlogDto>();
            CreateMap<Blog, BlogDetailsDto>();
            CreateMap<Blog, CreateBlogRequest>();

            CreateMap<Category, CategoryDto>();
            CreateMap<Comment, CommentDto>();
            CreateMap<Like, LikeDto>();
            
        }
    }
}
