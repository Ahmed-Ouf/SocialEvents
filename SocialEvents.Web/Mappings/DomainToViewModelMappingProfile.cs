using AutoMapper;
using SocialEvents.Model;
using SocialEvents.Web.ViewModels;

namespace SocialEvents.Web.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Category, CategoryViewModel>(MemberList.None).ReverseMap().ForAllMembers(opt => opt.Ignore());
            CreateMap<Gadget, GadgetViewModel>(MemberList.None).ReverseMap().ForAllMembers(opt => opt.Ignore());
        }
    }
}