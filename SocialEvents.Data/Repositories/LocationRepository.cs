using SocialEvents.Data.Infrastructure;
using SocialEvents.Model;
using System;
using System.Linq;

namespace SocialEvents.Data.Repositories
{
    public class LocationRepository : RepositoryBase<Location>, ILocationRepository
    {
        public LocationRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Category GetCategoryByName(string categoryName)
        {
            var category = this.DbContext.Categories.Where(c => c.Name == categoryName).FirstOrDefault();

            return category;
        }

    }

    public interface ILocationRepository : IRepository<Location>
    {
        Category GetCategoryByName(string categoryName);
    }
}