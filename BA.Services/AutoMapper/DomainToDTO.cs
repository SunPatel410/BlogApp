using AutoMapper;
using BA.Domains;
using BA.Services.Dtos;

namespace BA.Services.AutoMapper
{
    public class DomainToDto : Profile
    {
        public DomainToDto()
        {
            CreateMap<Blog, BlogDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Comment, CommentDto>();
            CreateMap<Like, LikeDto>();
            //CreateMap<User, UserDto>();
        }
    }
}
