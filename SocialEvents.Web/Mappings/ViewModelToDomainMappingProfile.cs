using AutoMapper;
using SocialEvents.Model;
using SocialEvents.Web.ViewModels;

namespace SocialEvents.Web.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
           
        }

        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }
    }
}