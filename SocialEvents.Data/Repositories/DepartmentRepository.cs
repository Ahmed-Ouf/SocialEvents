using SocialEvents.Data.Infrastructure;
using SocialEvents.Model;
using System;
using System.Linq;

namespace SocialEvents.Data.Repositories
{
    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Category GetCategoryByName(string categoryName)
        {
            var category = this.DbContext.Categories.Where(c => c.Name == categoryName).FirstOrDefault();

            return category;
        }

    }

    public interface IDepartmentRepository : IRepository<Department>
    {
        Category GetCategoryByName(string categoryName);
    }
}