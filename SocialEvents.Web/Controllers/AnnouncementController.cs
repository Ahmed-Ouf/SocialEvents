using Beneficiary.Web.Helpers;
using SocialEvents.Model;
using SocialEvents.Service;
using SocialEvents.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialEvents.Web.Controllers
{
    [RoleAuthorize(Roles = "SocialEventsAdmin")]
    public class AnnouncementController : BaseController
    {
        private readonly IAnnouncementService announcementService;
        public AnnouncementController(IAnnouncementService announcement)
        {
            announcementService = announcement;
        }
        // GET: AnnouncementViewModel
        public ActionResult Index()
        {
            var list = announcementService.GetAllAtive();
            return View(list);
        }

        // GET: AnnouncementViewModel/Details/5
        public ActionResult Details(Guid id)
        {
            var model = announcementService.GetById(id);
            return View(model);
        }

        // GET: AnnouncementViewModel/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: AnnouncementViewModel/Create
        [HttpPost]
        public ActionResult Create(AnnouncementViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    ConvertFileToBase64(model);
                    announcementService.Add(model.Announcement);
                    announcementService.SaveChanges();
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

        private void ConvertFileToBase64(AnnouncementViewModel model)
        {
            if (model.File != null && model.File.ContentLength > 0)
            {
                model.Announcement.EventImage = new EventImage();
                Stream fs = model.File.InputStream;
                BinaryReader br = new BinaryReader(fs);
                byte[] bytes = br.ReadBytes((int)fs.Length);
                string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                model.Announcement.EventImage.FileBase64 = base64String;
                model.Announcement.EventImage.Name = model.File.FileName;
            }
        }

        // GET: AnnouncementViewModel/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = announcementService.GetById(id);

            return View(new AnnouncementViewModel { Announcement = model });
        }

        // POST: AnnouncementViewModel/Edit/5
        [HttpPost]
        public ActionResult Edit(AnnouncementViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ConvertFileToBase64(model);
                    announcementService.Update(model.Announcement);
                    announcementService.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AnnouncementViewModel/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = announcementService.GetById(id);
            return View(model);
        }

        // POST: AnnouncementViewModel/Delete/5
        [HttpPost]
        public ActionResult Delete(Announcement model)
        {
            try
            {
                // TODO: Add delete logic here

                announcementService.Deactivate(model);
                announcementService.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }


        public ActionResult Publish(Guid id)
        {
            announcementService.Publish(id);
            announcementService.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
