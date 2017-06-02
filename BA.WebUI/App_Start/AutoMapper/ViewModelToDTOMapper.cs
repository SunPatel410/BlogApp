using AutoMapper;
using BA.Services.Dtos;
using BA.WebUI.ViewModels;

namespace BA.WebUI.AutoMapper
{
    public class ViewModelToDTOMapper : Profile
    {
        public ViewModelToDTOMapper()
        {
            CreateMap<CommentViewModel, CommentDto>();
        }
    }
}
