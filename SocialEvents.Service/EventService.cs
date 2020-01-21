using SocialEvents.Data.Infrastructure;
using SocialEvents.Data.Repositories;
using SocialEvents.Model;
using System.Collections.Generic;
using System.Linq;

namespace SocialEvents.Service
{
    // operations you want to expose
    public interface IEventService:IServiceBase<Event>
    {

    }

    public class EventService :ServiceBase<Event>, IEventService
    {
        private readonly IEventRepository EventRepository;

        public EventService(IRepository<Event> repository, IEventRepository EventRepository, IUnitOfWork unitOfWork)
            :base(repository,unitOfWork)
        {
            this.EventRepository = EventRepository;
        }

        #region IEventService Members


        #endregion IEventService Members
    }
}