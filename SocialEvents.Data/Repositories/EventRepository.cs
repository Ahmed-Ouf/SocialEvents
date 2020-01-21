using SocialEvents.Data.Infrastructure;
using SocialEvents.Model;
using System;
using System.Linq;

namespace SocialEvents.Data.Repositories
{
    public class EventRepository : RepositoryBase<Event>, IEventRepository
    {
        public EventRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Category GetCategoryByName(string categoryName)
        {
            var category = this.DbContext.Categories.Where(c => c.Name == categoryName).FirstOrDefault();

            return category;
        }

    }

    public interface IEventRepository : IRepository<Event>
    {
        Category GetCategoryByName(string categoryName);
    }
}