using SocialEvents.Data.Infrastructure;
using SocialEvents.Data.Repositories;
using SocialEvents.Model;
using SocialEvents.Service.FCM;
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
        IEnumerable<Event> GetAllAtiveByDepartment(Guid departmentId);
        bool IsDublicatedEventNumber(Guid id, string eventNumber);

        IEnumerable<Event> GetAllPending();
        IEnumerable<Event> GetAllComming();
    }

    public class EventService : ServiceBase<Event>, IEventService
    {
        private readonly IEventRepository EventRepository;

        public EventService(IRepository<Event> repository, IEventRepository EventRepository, IUnitOfWork unitOfWork)
            : base(repository, unitOfWork)
        {
            this.EventRepository = EventRepository;
        }
        public override void Add(Event model)
        {
            base.Add(model);
            if (model.Active && model.State == StateEnum.Approved && model.Published)
            {
                FCMNotificationService.Send(model.Name, model.Description);
            }
        }
        public override void Update(Event model)
        {
            base.Update(model);
            if (model.Active && model.State == StateEnum.Approved && model.Published)
            {
                FCMNotificationService.Send(model.Name, model.Description);
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

            if (entity.Active && entity.State == StateEnum.Approved && entity.Published)
            {
                FCMNotificationService.Send(entity.Name, entity.Description);
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