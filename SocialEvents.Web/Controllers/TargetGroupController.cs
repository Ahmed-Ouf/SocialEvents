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
    public class TargetGroupController : BaseController
    {
        private readonly ITargetGroupService TargetGroupService;
        public TargetGroupController(ITargetGroupService TargetGroup)
        {
            TargetGroupService = TargetGroup;
        }
        // GET: TargetGroup
        public ActionResult Index()
        {
            var list = TargetGroupService.GetAll();
            return View(list);
        }

        // GET: TargetGroup/Details/5
        public ActionResult Details(Guid id)
        {
            var model = TargetGroupService.GetById(id);
            return View(model);
        }

        // GET: TargetGroup/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: TargetGroup/Create
        [HttpPost]
        public ActionResult Create(TargetGroup model)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    TargetGroupService.Add(model);
                    TargetGroupService.SaveChanges();
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



        // GET: TargetGroup/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = TargetGroupService.GetById(id);

            return View(model);
        }

        // POST: TargetGroup/Edit/5
        [HttpPost]
        public ActionResult Edit(TargetGroup model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TargetGroupService.Update(model);
                    TargetGroupService.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TargetGroup/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = TargetGroupService.GetById(id);
            return View(model);
        }

        // POST: TargetGroup/Delete/5
        [HttpPost]
        public ActionResult Delete(TargetGroup model)
        {
            try
            {
                // TODO: Add delete logic here

                TargetGroupService.Deactivate(model);
                TargetGroupService.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult Activate(Guid id)
        {
            var model = TargetGroupService.GetById(id);
            TargetGroupService.Activate(model);
            TargetGroupService.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeActivate(Guid id)
        {
            var model = TargetGroupService.GetById(id);
            TargetGroupService.Deactivate(model);
            TargetGroupService.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
