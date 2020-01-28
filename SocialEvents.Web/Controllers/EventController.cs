using System;
using System.Collections.Generic;
using System.Web.Mvc;
using SocialEvents.Model;
using SocialEvents.Service;
using SocialEvents.Resources;
using SocialEvents.Web.ViewModels;
using System.Linq;

namespace SocialEvents.Web.Controllers
{

    public class EventController : BaseController
    {

        private readonly IEventService EventService;
        private readonly ICategoryService CategoryService;
        private readonly IDepartmentService DepartmentService;
        private readonly ILocationService LocationService;
        private readonly ITargetGroupService TargetGroupService;
        public EventController(IEventService Event, ICategoryService category, IDepartmentService department, ILocationService location, ITargetGroupService targetGroup)
        {
            EventService = Event;
            CategoryService = category;
            DepartmentService = department;
            LocationService = location;
            TargetGroupService = targetGroup;
            ViewBag.DDL = new Func<string, object, dynamic>(fullDropDownList);
        }
        //private


        private dynamic fullDropDownList(string switch_on, object selectedId)
        {
            dynamic resultSelectList;

            switch (switch_on)
            {
                case "CategoryId":
                    {
                        var list = CategoryService.GetAllAtive();
                        selectedId = selectedId ?? Guid.NewGuid().ToString();
                        var selectedItem = list.FirstOrDefault(s => s.Id == Guid.Parse(selectedId.ToString()));
                        resultSelectList = new SelectList(list, "Id", "Name", selectedItem);
                    }
                    break;

                case "DepartmentId":
                    {
                        var list = DepartmentService.GetAllAtive();
                        selectedId = selectedId ?? Guid.NewGuid().ToString();
                        var selectedItem = list.FirstOrDefault(s => s.Id == Guid.Parse(selectedId.ToString()));
                        resultSelectList = new SelectList(list, "Id", "Name", selectedItem);
                    }
                    break;

                case "LocationId":
                    {
                        var list = LocationService.GetAllAtive();
                        selectedId = selectedId ?? Guid.NewGuid().ToString();
                        var selectedItem = list.FirstOrDefault(s => s.Id == Guid.Parse(selectedId.ToString()));
                        resultSelectList = new SelectList(list, "Id", "Name", selectedItem);
                    }
                    break;

                case "TargetGroupId":
                    {
                        var list = TargetGroupService.GetAllAtive();
                        selectedId = selectedId ?? Guid.NewGuid().ToString();
                        var selectedItem = list.FirstOrDefault(s => s.Id == Guid.Parse(selectedId.ToString()));
                        resultSelectList = new SelectList(list, "Id", "Name", selectedItem);
                    }
                    break;

                case "State":
                    {
                        List<SelectListItem> list = new List<SelectListItem>();
                        list.Add(new SelectListItem() { Text = Resources.Resources.Pending, Value = "0" });
                        list.Add(new SelectListItem() { Text = Resources.Resources.Approved, Value = "1" });
                        list.Add(new SelectListItem() { Text = Resources.Resources.Rejected, Value = "2" });

                        selectedId = selectedId ?? -1;
                        var selectedItem = list.FirstOrDefault(s => s.Value == ((int)selectedId).ToString());

                        resultSelectList = new SelectList(list, "Value", "Text", selectedItem);
                    }
                    break;

                case "DaysOfWeek":
                    {
                        List<SelectListItem> list = new List<SelectListItem>();
                        list.Add(new SelectListItem() { Text = Resources.Resources.Sunday, Value = "0" });
                        list.Add(new SelectListItem() { Text = Resources.Resources.Monday, Value = "1" });
                        list.Add(new SelectListItem() { Text = Resources.Resources.Tuesday, Value = "2" });
                        list.Add(new SelectListItem() { Text = Resources.Resources.Wednesday, Value = "3" });
                        list.Add(new SelectListItem() { Text = Resources.Resources.Thursday, Value = "4" });
                        list.Add(new SelectListItem() { Text = Resources.Resources.Friday, Value = "5" });
                        list.Add(new SelectListItem() { Text = Resources.Resources.Saturday, Value = "6" });

                        selectedId = selectedId ?? new int[1] { 0 };
                        resultSelectList = new MultiSelectList(list, "Value", "Text", (int[])selectedId);
                    }
                    break;


                default:
                    resultSelectList = null;
                    break;
            }
            return resultSelectList;
        }


        // GET: Event
        public ActionResult Index()
        {
            var list = EventService.GetAllAtive();
            return View(list);
        }

        // GET: Event/Details/5
        public ActionResult Details(Guid id)
        {
            var model = EventService.GetById(id);
            return View(model);
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        [HttpPost]
        public ActionResult Create(Event model)
        {
            try
            {

                ValidateDateAndTime(model);
                if (ModelState.IsValid)
                {
                   
                    model.WeekDays = string.Join(",", model.DaysOfWeek);
                    EventService.Create(model);
                    EventService.SaveChanges();
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



        // GET: Event/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = EventService.GetById(id);
            if (!string.IsNullOrEmpty(model.WeekDays))
            {
                model.DaysOfWeek = model.WeekDays.Split(',').Select(e => int.Parse(e)).ToArray();
            }
            return View(model);
        }

        // POST: Event/Edit/5
        [HttpPost]
        public ActionResult Edit(Event model)
        {
            try
            {
                ValidateDateAndTime(model);
                if (ModelState.IsValid)
                {
                    model.WeekDays = string.Join(",", model.DaysOfWeek);
                    EventService.Update(model);
                    EventService.SaveChanges();
                }
                else
                {
                    return View(model);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Event/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = EventService.GetById(id);
            return View(model);
        }

        // POST: Event/Delete/5
        [HttpPost]
        public ActionResult Delete(Event model)
        {
            try
            {
                // TODO: Add delete logic here
                EventService.Deactivate(model);
                EventService.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }


        public ActionResult Publish(Guid id)
        {
            try
            {
                EventService.Publish(id);
                EventService.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Approval(Guid id)
        {
            var model = new ApprovalViewModel { Id = id };
            return View(model);
        }

        [HttpPost]
        public ActionResult Approval(ApprovalViewModel approval)
        {
            if (ModelState.IsValid)
            {
                var eventModel = new Event
                {
                    Id = approval.Id,
                    State = approval.State,
                    Reaseon = approval.Reason
                };

                EventService.Approval(eventModel);
                EventService.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        //private 
        private void ValidateDateAndTime(Event model)
        {
            if (model.TimeFrom > model.TimeTo)
            {
                ModelState.AddModelError("TimeTo", string.Format(Resources.Resources.ErrorMsgBigger, Resources.Resources.TimeTo, Resources.Resources.TimeFrom));
            }
            if (model.DateFrom > model.DateTo)
            {
                ModelState.AddModelError("DateTo", string.Format(Resources.Resources.ErrorMsgBigger, Resources.Resources.DateTo, Resources.Resources.DateFrom));
            }
        }

    }
}
