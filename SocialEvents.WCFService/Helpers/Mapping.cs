using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialEvents.ViewModel;
using SocialEvents.Model;


namespace SocialEvents.WCFService.Helpers
{
    public static class Mapping
    {
        public static IMapper Init()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Event, EventViewModel>(MemberList.None).ReverseMap().ForAllMembers(opt => opt.Ignore());
                cfg.CreateMap<Category, CategoryViewModel>(MemberList.None).ReverseMap().ForAllMembers(opt => opt.Ignore());
                cfg.CreateMap<Announcement, AnnouncementViewModel>(MemberList.None).ReverseMap().ForAllMembers(opt => opt.Ignore());
                cfg.CreateMap<EventImage, EventImageViewModel>(MemberList.None).ReverseMap().ForAllMembers(opt => opt.Ignore());

            });

            IMapper mapper = config.CreateMapper();

            return mapper;
        }
    }
}
