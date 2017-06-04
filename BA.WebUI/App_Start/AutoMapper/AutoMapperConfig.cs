using AutoMapper;

namespace BA.WebUI.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DTOtoViewModelMapping>();
                x.AddProfile<ViewModelToDTOMapping>();
            });
        }
    }
}
