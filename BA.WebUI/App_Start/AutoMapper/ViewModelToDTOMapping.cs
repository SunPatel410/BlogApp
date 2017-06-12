using AutoMapper;
using BA.Services.Dtos;
using BA.WebUI.ViewModels;
using BA.WebUI.ViewModels.BlogViewModels;

namespace BA.WebUI.AutoMapper
{
    public class ViewModelToDTOMapping : Profile
    {
        public ViewModelToDTOMapping()
        {
            CreateMap<BlogViewModel, BlogDto>();
            CreateMap<BlogDetailsViewModel, BlogDetailsDto>();
            CreateMap<CommentViewModel, CommentDto>();
            CreateMap<CategoryViewModel, CategoryDto>();
        }
    }
}
