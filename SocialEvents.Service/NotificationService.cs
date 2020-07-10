using SocialEvents.Data.Infrastructure;
using SocialEvents.Data.Repositories;
using SocialEvents.Model;
using SocialEvents.Service.FCM;
using System.Collections.Generic;
using System.Linq;

namespace SocialEvents.Service
{
    // operations you want to expose
    public interface INotificationService:IServiceBase<Notification>
    {

    }

    public class NotificationService :ServiceBase<Notification>, INotificationService
    {
        private readonly INotificationRepository NotificationRepository;

        public NotificationService(IRepository<Notification> repository, INotificationRepository NotificationRepository, IUnitOfWork unitOfWork)
            :base(repository,unitOfWork)
        {
            this.NotificationRepository = NotificationRepository;
        }


        #region INotificationService Members

        public override void Add(Notification model)
        {
            base.Add(model);
            if (model.Active)
            {
                FCMNotificationService.Send("تنبية", model.Name);
            }
        }
        #endregion INotificationService Members
    }
}