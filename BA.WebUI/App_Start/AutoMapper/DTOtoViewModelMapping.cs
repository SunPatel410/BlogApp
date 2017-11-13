using AutoMapper;
using BA.Services.Dtos;
using BA.WebUI.ViewModels;
using BA.WebUI.ViewModels.BlogViewModels;

namespace BA.WebUI.AutoMapper
{
    public class DTOtoViewModelMapping : Profile
    {
        public DTOtoViewModelMapping()
        {
          
            CreateMap<BlogDto, BlogViewModel>();
            CreateMap<BlogDetailsDto, BlogDetailsViewModel>();
            CreateMap<CommentDto, CommentViewModel>();
            CreateMap<CategoryDto, CategoryViewModel>();
            CreateMap<BlogDto, UpdateBlogViewModel>();
        }
    }
    }

