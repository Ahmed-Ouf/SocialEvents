using System.Collections.Generic;
using System.ServiceModel;
using SocialEvents.ViewModel;

namespace SocialEvents.WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAnnouncementWCFService" in both code and config file together.
    [ServiceContract]
    public interface IAnnouncementWCFService
    {
        [OperationContract]
        IEnumerable<AnnouncementViewModel> GetAnnouncements();
    }
}
