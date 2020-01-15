using AutoMapper;
using SocialEvents.Model;
using SocialEvents.Web.ViewModels;

namespace SocialEvents.Web.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<GadgetFormViewModel, Gadget>(MemberList.None)
                .ForMember(g => g.Name, map => map.MapFrom(vm => vm.GadgetTitle))
                .ForMember(g => g.Description, map => map.MapFrom(vm => vm.GadgetDescription))
                .ForMember(g => g.Price, map => map.MapFrom(vm => vm.GadgetPrice))
                .ForMember(g => g.Image, map => map.MapFrom(vm => vm.File.FileName))
                .ForMember(g => g.CategoryId, map => map.MapFrom(vm => vm.GadgetCategory)).ReverseMap().ForAllMembers(opt => opt.Ignore()); ;
        }

        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }
    }
}