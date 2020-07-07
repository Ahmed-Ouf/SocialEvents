using System;
using System.Collections.Generic;
using System.Web.Mvc;
using SocialEvents.Model;
using SocialEvents.Service;
using SocialEvents.Resources;
using SocialEvents.Web.ViewModels;
using System.Linq;
using Beneficiary.Web.Helpers;
using SocialEvents.ViewModel;

namespace SocialEvents.Web.Controllers
{
    //[RoleAuthorize(Roles = "SocialEventsAdmin,SocialEventsSupervisor")]

    public class EventController : BaseController
    {

        private readonly IEventService EventService;
        private readonly ICategoryService CategoryService;
        private readonly IDepartmentService DepartmentService;
        private readonly ILocationService LocationService;
        private readonly ITargetGroupService TargetGroupService;
        private Department department;
        private bool IsSocialServicesDept;
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
                        resultSelectList = new SelectList(list, "Id", "DepartmentNameAr", selectedItem);
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

                case "RegistrationState":
                    {
                        List<SelectListItem> list = new List<SelectListItem>();
                        list.Add(new SelectListItem() { Text = Resources.Resources.Available, Value = "0" });
                        list.Add(new SelectListItem() { Text = Resources.Resources.Completed, Value = "1" });
                        list.Add(new SelectListItem() { Text = Resources.Resources.Expired, Value = "2" });
                        list.Add(new SelectListItem() { Text = Resources.Resources.Closed, Value = "3" });

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

        private void CheckAdminDepartment()
        {
            var sessionUserInfo = (CurrentUserViewModel)Session["current-user"];

            string socialEventsDeptId = "20870";//"20870" => إدارة الخدمات الإجتماعية ;
            string GeneralEducationDeptId = "20950";//"20870" => إدارة التعليم العام ;

#if DEBUG
            ViewBag.IsSocialServicesDept = IsSocialServicesDept = socialEventsDeptId == socialEventsDeptId;
            ViewBag.Department = department = DepartmentService.GetBySafeerDepartmentId(socialEventsDeptId);
#else
            //TODO: Remove commented
        ViewBag.IsSocialServicesDept = IsSocialServicesDept = (socialEventsDeptId == sessionUserInfo.SafeerDepartmentId);
        ViewBag.Department = department = DepartmentService.GetBySafeerDepartmentId(sessionUserInfo.SafeerDepartmentId);
           

#endif



        }


        // GET: Event
        public ActionResult Index()
        {
            List<Event> events = new List<Event>();
            CheckAdminDepartment();
            if (!IsSocialServicesDept)
            {
                events = EventService.GetAllAtiveByDepartment(department.Id).ToList();
            }
            else
            {
                events = EventService.GetAllAtive().ToList();
            }
            return View(events);
        }

        // GET: Event/Details/5
        public ActionResult Details(Guid id)
        {
            CheckAdminDepartment();
            var model = EventService.GetById(id);
            return View(model);
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            CheckAdminDepartment();
            return View();

        }

        // POST: Event/Create
        [HttpPost]
        public ActionResult Create(Event model)
        {
            try
            {
                CheckAdminDepartment();
                ValidateDateAndTime(model);
                ValidateEventNumber(model);
                if (ModelState.IsValid)
                {

                    model.WeekDays = string.Join(",", model.DaysOfWeek);
                    EventService.Add(model);
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
            CheckAdminDepartment();
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
                CheckAdminDepartment();
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
            CheckAdminDepartment();
            var model = EventService.GetById(id);
            return View(model);
        }

        // POST: Event/Delete/5
        [HttpPost]
        public ActionResult Delete(Event model)
        {
            try
            {
                CheckAdminDepartment();
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

        /// <summary>
        /// this method make event published and approved
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
            CheckAdminDepartment();
            var model = new ApprovalViewModel { Id = id };
            return View(model);
        }

        [HttpPost]
        public ActionResult Approval(ApprovalViewModel approval)
        {
            CheckAdminDepartment();
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

        public ActionResult PendingEvents()
        {
            List<Event> events = new List<Event>();
            CheckAdminDepartment();
            if (!IsSocialServicesDept)
            {
                events = EventService.GetAllAtiveByDepartment(department.Id).ToList();
            }
            else
            {
                events = EventService.GetAllPending().ToList();
            }
            return View(events);
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

        private void ValidateEventNumber(Event model)
        {
            if (EventService.IsDublicatedEventNumber(model.Id,model.EventNumber))
            {
                ModelState.AddModelError("EventNumber", string.Format(Resources.Resources.DublicatedEventNumber, Resources.Resources.EventNumber));
            }
        }

    }
}
