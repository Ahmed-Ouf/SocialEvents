using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using vm = SocialEvents.ViewModel;


namespace SocialEvents.WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEventWCFService" in both code and config file together.
    [ServiceContract]
    public interface IEventWCFService
    {
        [OperationContract]
        IEnumerable<vm.Event> GetEvents();
    }
}
