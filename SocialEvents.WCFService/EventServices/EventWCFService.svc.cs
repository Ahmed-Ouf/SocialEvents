using SocialEvents.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using vm = SocialEvents.ViewModel;

namespace SocialEvents.WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EventWCFService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EventWCFService.svc or EventWCFService.svc.cs at the Solution Explorer and start debugging.
    public class EventWCFService : IEventWCFService
    {
        private readonly IEventService _EventService;
        public EventWCFService(IEventService EventService)
        {
            _EventService = EventService;
        }

        public IEnumerable<vm.Event> GetEvents()
        {

            var result = _EventService.GetAllPublished().Select(e =>

            new vm.Event
            {
                Id = e.Id,
                Address = e.Address,
                EventNumber = e.EventNumber,
                DateFrom = e.DateFrom,
                DateTo = e.DateTo,
                TimeFrom = e.TimeFrom,
                TimeTo = e.TimeTo,
                Fees = e.Fees,
                Name = e.Name,
                Department = new vm.Department { Name = e.Department.Name },
                Location = new vm.Location { Longitude = e.Location.Longitude, Latitude = e.Location.Latitude, Name = e.Location.Name },
                Category = new vm.Category { Name = e.Name },
                DaysOfWeek = e.DaysOfWeek,
                TargetAge = e.TargetAge,
                Description = e.Description,
                EventUrl = e.EventUrl,
                FacebookUrl = e.FacebookUrl,
                twitterUrl = e.twitterUrl,
                InstagramUrl = e.InstagramUrl,
                WeekDays = e.WeekDays

            }


            ).ToList();

            return result;
        }
    }
}
