using SocialEvents.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SocialEvents.ViewModel;

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

        public IEnumerable<EventViewModel> GetEvents()
        {

            var result = _EventService.GetAllPublished().Select(e =>

            new EventViewModel
            {
                Id = e.Id,
                CategoryId=e.CategoryId,
                LocationId=e.LocationId,
                TargetGroupId=e.TargetGroupId,
                DepartmentId=e.DepartmentId,
                Address = e.Address,
                EventNumber = e.EventNumber,
                DateFrom = e.DateFrom,
                DateTo = e.DateTo,
                TimeFrom = e.TimeFrom,
                TimeTo = e.TimeTo,
                Fees = e.Fees,
                Name = e.Name,
                Department = new DepartmentViewModel { Id = e.Department.Id, DepartmentNameEn = e.Department.DepartmentNameEn },
                Location = new LocationViewModel {  Id=e.LocationId,Longitude = e.Location.Longitude, Latitude = e.Location.Latitude, Name = e.Location.Name },
                Category = new CategoryViewModel { Id=e.Category.Id , Name = e.Category.Name},
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
