using SocialEvents.Data.Infrastructure;
using SocialEvents.Model;
using System;
using System.Linq;

namespace SocialEvents.Data.Repositories
{
    public class TargetGroupRepository : RepositoryBase<TargetGroup>, ITargetGroupRepository
    {
        public TargetGroupRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Category GetCategoryByName(string categoryName)
        {
            var category = this.DbContext.Categories.Where(c => c.Name == categoryName).FirstOrDefault();

            return category;
        }

    }

    public interface ITargetGroupRepository : IRepository<TargetGroup>
    {
        Category GetCategoryByName(string categoryName);
    }
}