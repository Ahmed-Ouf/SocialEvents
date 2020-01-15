using AutoMapper;

namespace SocialEvents.Web.Mappings
{
    public static class AutoMapperConfiguration
    {
        public static MapperConfiguration Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DomainToViewModelMappingProfile>();
                cfg.AddProfile<ViewModelToDomainMappingProfile>();
            });

            config.AssertConfigurationIsValid();
            return config;
        }
    }
}