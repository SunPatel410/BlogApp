using AutoMapper;
using BA.Services.Dtos;
using BA.WebUI.Models;
using BA.WebUI.ViewModels;

namespace BA.WebUI.AutoMapper
{
    public class DTOtoViewModelMapping : Profile
    {
        public DTOtoViewModelMapping()
        {
            CreateMap<CommentDto, CommentViewModel>();
            CreateMap<UserDto, ApplicationUser>();
            CreateMap<CategoryDto, CategoryViewModel>();
            CreateMap<CommentDto, CommentViewModel>();
            CreateMap<BlogDto, BlogViewModel>();
            CreateMap<BlogDetailsDto, BlogDetailViewModel>();
        }
    }
    }

