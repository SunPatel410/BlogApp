using AutoMapper;
using BA.Services.Dtos;
using BA.WebUI.ViewModels;

namespace BA.WebUI.AutoMapper
{
    public class DTOtoViewModelMapper : Profile
    {
        public DTOtoViewModelMapper()
        {
            CreateMap<CommentDto, CommentViewModel>();
        }
    }
}
