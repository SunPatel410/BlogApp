using AutoMapper;
using BA.Services.Dtos;
using BA.WebUI.ViewModels;

namespace BA.WebUI.AutoMapper
{
    public class DTOtoViewModelMapping : Profile
    {
        public DTOtoViewModelMapping()
        {
            CreateMap<BlogDto, BlogViewModel>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                //.ForMember(dest => dest.UserName, opts => opts.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.Title))
                .ForMember(dest => dest.CategoryName, opts => opts.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.Description, opts => opts.MapFrom(src => src.Description))
                //.ForMember(dest => dest.Comments, opts => opts.MapFrom(src => src.Comments))
                .ForMember(dest => dest.PostedDate, opts => opts.MapFrom(src => src.PostedDate))
                .ForMember(dest => dest.LikeCount, opts => opts.MapFrom(src => src.Likes));

            CreateMap<BlogDetailsDto, BlogDetailsViewModel>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                //.ForMember(dest => dest.UserName, opts => opts.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.Title))
                //.ForMember(dest => dest.CategoryName, opts => opts.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.Description, opts => opts.MapFrom(src => src.Description))
                .ForMember(dest => dest.PostedDate, opts => opts.MapFrom(src => src.PostedDate));

            //need to map create 

            //need to map update

            CreateMap<CommentDto, CommentViewModel>();
            CreateMap<CategoryDto, CategoryViewModel>();
        }
    }
    }

