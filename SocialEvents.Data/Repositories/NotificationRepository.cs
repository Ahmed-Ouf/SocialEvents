using SocialEvents.Data.Infrastructure;
using SocialEvents.Model;
using System.Linq;

namespace SocialEvents.Data.Repositories
{
    public class NotificationRepository : RepositoryBase<Notification>, INotificationRepository
    {
        public NotificationRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Category GetCategoryByName(string categoryName)
        {
            var category = this.DbContext.Categories.Where(c => c.Name == categoryName).FirstOrDefault();

            return category;
        }

    }

    public interface INotificationRepository : IRepository<Notification>
    {
        Category GetCategoryByName(string categoryName);
    }
}