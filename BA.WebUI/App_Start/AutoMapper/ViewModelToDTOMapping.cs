using AutoMapper;
using BA.Services.Dtos;
using BA.WebUI.ViewModels;

namespace BA.WebUI.AutoMapper
{
    public class ViewModelToDTOMapping : Profile
    {
        public ViewModelToDTOMapping()
        {
            CreateMap<CommentViewModel, CommentDto>();
            CreateMap<CategoryViewModel, CategoryDto>();
            CreateMap<CommentViewModel,CommentDto >();
            CreateMap<BlogViewModel, BlogDto>();
            CreateMap<BlogDetailViewModel, BlogDetailsDto>();
        }
    }
}
