using AutoMapper;

namespace BA.WebUI.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DTOtoViewModelMapper>();
                x.AddProfile<ViewModelToDTOMapper>();
            });
        }
    }
}
