using SocialEvents.Service;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using vm = SocialEvents.ViewModel;
namespace SocialEvents.WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AnnouncementWCFService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AnnouncementWCFService.svc or AnnouncementWCFService.svc.cs at the Solution Explorer and start debugging.
    public class AnnouncementWCFService : IAnnouncementWCFService
    {

    
        private readonly IAnnouncementService _AnnouncementService;
        public AnnouncementWCFService(IAnnouncementService Announcement)
        {
            _AnnouncementService = Announcement;
        }
        public IEnumerable<vm.Announcement> GetAnnouncements()
        {
            var result = _AnnouncementService.GetAllPublished().Select(e=>
            new vm.Announcement
            {
                Id=e.Id,
                Name=e.Name,
                EventImage=new vm.EventImage
                {
                    Name=e.EventImage.Name,
                    FileBase64=e.EventImage.FileBase64
                }
            }
            ).ToList();

            return result;
        }
    }
}
