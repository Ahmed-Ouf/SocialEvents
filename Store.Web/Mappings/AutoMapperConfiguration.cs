using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Web.Mappings
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