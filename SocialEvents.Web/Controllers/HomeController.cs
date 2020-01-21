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
        private readonly ICategoryService categoryService;
        private readonly IAnnouncementService announcementService;

        public HomeController(ICategoryService categoryService,IAnnouncementService announcement)
        {
            this.categoryService = categoryService;
            this.announcementService = announcement;
        }

        public ActionResult Index2()
        {
            var list = this.announcementService.GetAll();
            return View(list);

        }

        // GET: Home
        public ActionResult Index(string category = null)
        {
            //IEnumerable<CategoryViewModel> viewModelGadgets;
            //IEnumerable<Category> categories;

            //categories = categoryService.GetCategories(category).ToList();

            //viewModelGadgets = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);

            var list = this.announcementService.GetAll();
            return View(list);
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