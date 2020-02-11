using SocialEvents.Service;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SocialEvents.ViewModel;
using AutoMapper;
using SocialEvents.Model;

namespace SocialEvents.WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AnnouncementWCFService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AnnouncementWCFService.svc or AnnouncementWCFService.svc.cs at the Solution Explorer and start debugging.
    public class AnnouncementWCFService : IAnnouncementWCFService
    {


        private readonly IAnnouncementService _AnnouncementService;
        private readonly IMapper _mapper;
        public AnnouncementWCFService(IAnnouncementService Announcement, IMapper mapper)
        {
            _AnnouncementService = Announcement;
            _mapper = mapper;
        }
        public IEnumerable<AnnouncementViewModel> GetAnnouncements()
        {
            var entities = _AnnouncementService.GetAllPublished().ToList();
            var models = _mapper.Map<List<Announcement>, List<AnnouncementViewModel>>(entities);

            return models;
        }
    }
}
