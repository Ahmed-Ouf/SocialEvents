using SocialEvents.Data.Infrastructure;
using SocialEvents.Data.Repositories;
using SocialEvents.Model;
using System.Collections.Generic;
using System.Linq;

namespace SocialEvents.Service
{
    // operations you want to expose
    public interface ICategoryService:IServiceBase<Category>
    {
  
    }

    public class CategoryService : ServiceBase<Category>, ICategoryService
    {
        private readonly ICategoryRepository categorysRepository;

        public CategoryService(IRepository<Category> repository, ICategoryRepository categorysRepository, IUnitOfWork unitOfWork)
             : base(repository, unitOfWork)
        {
            this.categorysRepository = categorysRepository;
        }

        #region ICategoryService Members
        

        #endregion ICategoryService Members
    }
}