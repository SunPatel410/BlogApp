using AutoMapper;
using BA.Services.Dtos;
using BA.WebUI.ViewModels;

namespace BA.WebUI.AutoMapper
{
    public class ViewModelToDTOMapping : Profile
    {
        public ViewModelToDTOMapping()
        {
            CreateMap<BlogViewModel, BlogDto>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.User.UserName, opts => opts.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.Title))
                .ForMember(dest => dest.Category.Name, opts => opts.MapFrom(src => src.CategoryName))
                .ForMember(dest => dest.Description, opts => opts.MapFrom(src => src.Description))
                .ForMember(dest => dest.Comments, opts => opts.MapFrom(src => src.Comments))
                .ForMember(dest => dest.Likes, opts => opts.MapFrom(src => src.LikeCount));

            CreateMap<BlogDetailsViewModel, BlogDetailsDto>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.User.UserName, opts => opts.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.Title))
                .ForMember(dest => dest.Category.Name, opts => opts.MapFrom(src => src.CategoryName))
                .ForMember(dest => dest.Description, opts => opts.MapFrom(src => src.Description))
                .ForMember(dest => dest.PostedDate, opts => opts.MapFrom(src => src.PostedDate));

            CreateMap<CommentViewModel, CommentDto>();
            CreateMap<CategoryViewModel, CategoryDto>();
        }
    }
}
