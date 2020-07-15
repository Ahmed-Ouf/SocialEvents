using SocialEvents.Data.Infrastructure;
using SocialEvents.Data.Repositories;
using SocialEvents.Model;
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
        private readonly IFCMNotificationService FCMNotificationService;

        public NotificationService(IRepository<Notification> repository, IFCMNotificationService fCMNotificationService, INotificationRepository NotificationRepository, IUnitOfWork unitOfWork)
            :base(repository,unitOfWork)
        {
            this.NotificationRepository = NotificationRepository;
            FCMNotificationService =  fCMNotificationService;
        }


        #region INotificationService Members

        public override void Add(Notification model)
        {
            base.Add(model);
            if (model.Active)
            {
                FCMNotificationService.SendNotification("تنبية", model.Name);
            }
        }
        #endregion INotificationService Members
    }
}