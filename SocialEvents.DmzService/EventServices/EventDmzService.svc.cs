using SocialEvents.DmzService.EventWCFServiceRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using vm = SocialEvents.ViewModel;

namespace SocialEvents.DmzService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EventWCFService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EventWCFService.svc or EventWCFService.svc.cs at the Solution Explorer and start debugging.
    public class EventDmzService : IEventWCFService
    {
        private readonly EventWCFServiceClient _EventService;
        public EventDmzService()
        {
            _EventService = new EventWCFServiceClient();
        }

        public List<vm.Event> GetEvents()
        {

            var result = _EventService.GetEvents();

            return result;
        }
    }
}
