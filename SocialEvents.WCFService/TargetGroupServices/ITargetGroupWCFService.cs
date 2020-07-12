using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using SocialEvents.ViewModel;

namespace SocialEvents.WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITargetGroupService" in both code and config file together.
    [ServiceContract]
    public interface ITargetGroupWCFService
    {
        [OperationContract]
        IEnumerable<TargetGroupViewModel> GetTargetGroups();
    }
}
