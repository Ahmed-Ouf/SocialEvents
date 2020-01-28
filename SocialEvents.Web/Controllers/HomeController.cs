using SocialEvents.Model;
using SocialEvents.Service;
using SocialEvents.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SocialEvents.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IEventService EventService;
        private readonly ICategoryService CategoryService;
        private readonly IDepartmentService DepartmentService;
        private readonly ILocationService LocationService;
        private readonly ITargetGroupService TargetGroupService;
        public HomeController(IEventService Event, ICategoryService category, IDepartmentService department, ILocationService location, ITargetGroupService targetGroup)
        {
            EventService = Event;
            CategoryService = category;
            DepartmentService = department;
            LocationService = location;
            TargetGroupService = targetGroup;
        }



        // GET: Home
        public ActionResult Index()
        {
            var list = EventService.GetAllAtive();
            var model = new Statistics();
            model.TargetGroups = list.GroupBy(e => e.TargetGroupId).Select(g => new ChartItem { Id = g.Key, Name = g.FirstOrDefault().TargetGroup.Name, Count = g.Count() }).ToList();
            model.Cateogries = list.GroupBy(e => e.CategoryId).Select(g => new ChartItem { Id = g.Key, Name = g.FirstOrDefault().Category.Name, Count = g.Count() }).ToList();
            model.Locations = list.GroupBy(e => e.LocationId).Select(g => new ChartItem { Id = g.Key, Name = g.FirstOrDefault().Location.Name, Count = g.Count() }).ToList();
            model.MonthEvents = list.Select(e => new { MonthYear = e.DateFrom.ToString("yyyy-MM") })
                .GroupBy(e => e.MonthYear).Select(g => new ChartItem { Name = g.Key, Count = g.Count() }).ToList();



            return View(model);
        }



        [HttpPost]
        public ActionResult Create(GadgetFormViewModel newGadget)
        {
            if (newGadget != null && newGadget.File != null)
            {

                string gadgetPicture = System.IO.Path.GetFileName(newGadget.File.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/images/"), gadgetPicture);
                newGadget.File.SaveAs(path);

            }

            //var category = categoryService.GetCategory(newGadget.GadgetCategory);
            return null;// RedirectToAction("Index", new { category = category.Name });
        }
    }
}