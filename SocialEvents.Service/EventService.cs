using SocialEvents.Data.Infrastructure;
using SocialEvents.Data.Repositories;
using SocialEvents.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialEvents.Service
{
    // operations you want to expose
    public interface IEventService : IServiceBase<Event>
    {
        void Publish(Guid id);
        void Approval(Event eventModel);
        IEnumerable<Event> GetAllPublished();
        IEnumerable<Event> GetAllApprovedPublished();
        IEnumerable<Event> GetAllAtiveByDepartment(Guid departmentId);
        bool IsDublicatedEventNumber(Guid id, string eventNumber);

        IEnumerable<Event> GetAllPending();
        IEnumerable<Event> GetAllComming();
    }

    public class EventService : ServiceBase<Event>, IEventService
    {
        private readonly IEventRepository EventRepository;
        private readonly ICategoryRepository CategoryRepository;
        private readonly IFCMNotificationService FCMNotificationService;

        public EventService(IRepository<Event> repository, ICategoryRepository categoryRepository, IFCMNotificationService fCMNotificationService, IEventRepository EventRepository, IUnitOfWork unitOfWork)
            : base(repository, unitOfWork)
        {
            this.EventRepository = EventRepository;
            this.FCMNotificationService = fCMNotificationService;
            CategoryRepository = categoryRepository;
        }
        public override void Add(Event model)
        {
            base.Add(model);
            var entity = GetById(model.Id);

            var cat = CategoryRepository.GetById(model.CategoryId);
            if (model.Active && model.State == StateEnum.Approved && model.Published)
            {
                FCMNotificationService.Send(cat.Name, model.Name);
            }
        }
        public override void Update(Event model)
        {
            try
            {
                base.Update(model);
                var cat = CategoryRepository.GetById(model.CategoryId);
                if (model.Active && model.State == StateEnum.Approved && model.Published)
                {
                    FCMNotificationService.Send(cat.Name, model.Name);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void Approval(Event eventModel)
        {
            var entity = GetById(eventModel.Id);
            entity.State = eventModel.State;
            entity.Reaseon = eventModel.Reaseon;
        }

        public IEnumerable<Event> GetAllAtiveByDepartment(Guid departmentId)
        {
            var result = EventRepository.GetAll().Where(e => (departmentId == null || e.DepartmentId == departmentId) && e.Active).ToList();
            return result;
        }

        public IEnumerable<Event> GetAllPublished()
        {
            var result = EventRepository.GetAll().Where(e => e.Published && e.Active);
            return result;
        }

        public IEnumerable<Event> GetAllApprovedPublished()
        {
            var result = EventRepository.GetAll().Where(e => e.Published && e.Active && e.State == StateEnum.Approved);
            return result;
        }
        public IEnumerable<Event> GetAllPending()
        {
            var result = EventRepository.GetAll().Where(e => e.State == StateEnum.Pending && e.Active);
            return result;
        }

        public bool IsDublicatedEventNumber(Guid id, string eventNumber)
        {
            var result = EventRepository.GetAll().Where(e => e.Id != id && e.EventNumber == eventNumber)?.Any() ?? false;
            return result;
        }

        public void Publish(Guid id)
        {
            var entity = GetById(id);
            entity.Published = true;
            entity.State = StateEnum.Approved;
            var cat = CategoryRepository.GetById(entity.CategoryId);
            if (entity.Active && entity.State == StateEnum.Approved && entity.Published)
            {
                FCMNotificationService.Send(cat.Name, entity.Name);
            }
        }

        public IEnumerable<Event> GetAllComming()
        {
            var year = DateTime.Now.Year;
            var month = DateTime.Now.Month;
            var day = DateTime.Now.Day;
            var result = EventRepository.GetAll().Where(e =>
            e.State == StateEnum.Approved
            && e.Active
            && e.DateFrom.Year >= year
            && e.DateFrom.Month >= month
            );
            return result;
        }

        #region IEventService Members


        #endregion IEventService Members
    }
}