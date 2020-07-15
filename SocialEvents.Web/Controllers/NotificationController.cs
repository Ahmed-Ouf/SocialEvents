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
    [RoleAuthorize(Roles = "SocialEventsAdmin")]
    public class NotificationController : BaseController
    {
        private readonly INotificationService NotificationService;
        public NotificationController(INotificationService Notification)
        {
            NotificationService = Notification;
        }
        // GET: Notification
        public ActionResult Index()
        {
            var list = NotificationService.GetAllAtive();
            return View(list);
        }

        // GET: Notification/Details/5
        public ActionResult Details(Guid id)
        {
            var model = NotificationService.GetById(id);
            return View(model);
        }

        // GET: Notification/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Notification/Create
        [HttpPost]
        public ActionResult Create(Notification model)
        {
            try
            {
                if (ModelState.IsValid)
                {

            
                    NotificationService.Add(model);
                    NotificationService.SaveChanges();
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
 
        

        // GET: Notification/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = NotificationService.GetById(id);

            return View(model);
        }

        // POST: Notification/Edit/5
        [HttpPost]
        public ActionResult Edit(Notification model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    NotificationService.Update(model);
                    NotificationService.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Notification/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = NotificationService.GetById(id);
            return View(model);
        }

        // POST: Notification/Delete/5
        [HttpPost]
        public ActionResult Delete(Notification model)
        {
            try
            {
                // TODO: Add delete logic here

                NotificationService.Deactivate(model);
                NotificationService.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
