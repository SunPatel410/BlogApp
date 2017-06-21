using AutoMapper;
using BA.Services.AutoMapper;

namespace BA.WebUI.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToDto>();
                x.AddProfile<DTOtoViewModelMapping>();
                x.AddProfile<ViewModelToDTOMapping>();
            });
        }
    }
}
