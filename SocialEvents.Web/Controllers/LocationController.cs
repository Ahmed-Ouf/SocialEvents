using Beneficiary.Web.Helpers;
using SocialEvents.Model;
using SocialEvents.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialEvents.Web.Controllers
{
    //[RoleAuthorize(Roles = "SocialEventsAdmin")]
    public class LocationController : BaseController
    {
        private readonly ILocationService LocationService;
        public LocationController(ILocationService Location)
        {
            LocationService = Location;
        }
        // GET: Location
        public ActionResult Index()
        {
            var list = LocationService.GetAll();
            return View(list);
        }

        // GET: Location/Details/5
        public ActionResult Details(Guid id)
        {
            var model = LocationService.GetById(id);
            return View(model);
        }

        // GET: Location/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Location/Create
        [HttpPost]
        public ActionResult Create(Location model)
        {
            try
            {
                if (ModelState.IsValid)
                {

            
                    LocationService.Add(model);
                    LocationService.SaveChanges();
                }
                else
                {
                    return View(model);
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
 
        

        // GET: Location/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = LocationService.GetById(id);

            return View(model);
        }

        // POST: Location/Edit/5
        [HttpPost]
        public ActionResult Edit(Location model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LocationService.Update(model);
                    LocationService.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Location/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = LocationService.GetById(id);
            return View(model);
        }

        // POST: Location/Delete/5
        [HttpPost]
        public ActionResult Delete(Location model)
        {
            try
            {
                // TODO: Add delete logic here

                LocationService.Deactivate(model);
                LocationService.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public ActionResult Activate(Guid id)
        {
            var model = LocationService.GetById(id);
            LocationService.Activate(model);
                LocationService.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeActivate(Guid id)
        {
            var model = LocationService.GetById(id);
            LocationService.Deactivate(model);
                LocationService.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
