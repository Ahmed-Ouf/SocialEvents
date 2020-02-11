using SocialEvents.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SocialEvents.ViewModel;
using AutoMapper;
using SocialEvents.Model;

namespace SocialEvents.WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EventWCFService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EventWCFService.svc or EventWCFService.svc.cs at the Solution Explorer and start debugging.
    public class EventWCFService : IEventWCFService
    {
        private readonly IEventService _EventService;
        private readonly IMapper _mapper;
        public EventWCFService(IEventService EventService,IMapper mapper)
        {
            _EventService = EventService;
            _mapper = mapper;
        }

        public IEnumerable<EventViewModel> GetEvents()
        {
            var entities=_EventService.GetAllPublished().ToList();
            var models = _mapper.Map<List<Event>, List<EventViewModel>>(entities);
            return models;
        }
    }
}
