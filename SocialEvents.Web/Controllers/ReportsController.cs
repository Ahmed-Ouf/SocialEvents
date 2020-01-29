using SocialEvents.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialEvents.Web.Controllers
{
    public class ReportsController : BaseController
    {

        private readonly IEventService EventService;
        private readonly ICategoryService CategoryService;
        private readonly IDepartmentService DepartmentService;
        private readonly ILocationService LocationService;
        private readonly ITargetGroupService TargetGroupService;
        public ReportsController(IEventService Event, ICategoryService category, IDepartmentService department, ILocationService location, ITargetGroupService targetGroup)
        {
            EventService = Event;
            CategoryService = category;
            DepartmentService = department;
            LocationService = location;
            TargetGroupService = targetGroup;
        }
        // GET: Reports
        public ActionResult Index()
        {
            var model = EventService.GetAllAtive();
            return View(model);
        }

        public ActionResult RDLC()
        {
          
            return View();
        }
    }
}