using AutoMapper;
using BA.Services.Dtos;
using BA.WebUI.ViewModels;

namespace BA.WebUI.AutoMapper
{
    public class DTOtoViewModelMapping : Profile
    {
        public DTOtoViewModelMapping()
        {
            CreateMap<BlogDto, BlogViewModel>();
            CreateMap<BlogDetailsDto, BlogDetailViewModel>();
            CreateMap<CommentDto, CommentViewModel>();
            CreateMap<CategoryDto, CategoryViewModel>();
            CreateMap<CommentDto, CommentViewModel>();
        }
    }
    }

