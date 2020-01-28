﻿using SocialEvents.Data.Infrastructure;
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
    }

    public class EventService : ServiceBase<Event>, IEventService
    {
        private readonly IEventRepository EventRepository;

        public EventService(IRepository<Event> repository, IEventRepository EventRepository, IUnitOfWork unitOfWork)
            : base(repository, unitOfWork)
        {
            this.EventRepository = EventRepository;
        }

        public void Approval(Event eventModel)
        {
            var entity = GetById(eventModel.Id);
            entity.State = eventModel.State;
            entity.Reaseon = eventModel.Reaseon;
        }

        public void Publish(Guid id)
        {
            var entity = GetById(id);
            entity.Published = true;
            entity.State = StateEnum.Approved;
        }

        #region IEventService Members


        #endregion IEventService Members
    }
}