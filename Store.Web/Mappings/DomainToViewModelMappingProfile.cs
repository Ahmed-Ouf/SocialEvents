using AutoMapper;
using Store.Model;
using Store.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Web.Mappings
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