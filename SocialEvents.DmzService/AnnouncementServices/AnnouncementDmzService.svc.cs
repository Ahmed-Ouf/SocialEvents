using SocialEvents.DmzService.AnnouncementWCFServiceRef;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using vm = SocialEvents.ViewModel;

namespace SocialEvents.DmzService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AnnouncementWCFService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AnnouncementWCFService.svc or AnnouncementWCFService.svc.cs at the Solution Explorer and start debugging.
    public class AnnouncementDmzService : IAnnouncementWCFService
    {


        private readonly AnnouncementWCFServiceClient _AnnouncementService;
        public AnnouncementDmzService()
        {
            _AnnouncementService = new AnnouncementWCFServiceClient();
        }

        public List<vm.AnnouncementViewModel> GetAnnouncements()
        {
            var result = _AnnouncementService.GetAnnouncements();
            return result;
        }
    }
}
