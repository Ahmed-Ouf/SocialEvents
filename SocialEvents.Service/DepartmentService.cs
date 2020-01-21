using SocialEvents.Data.Infrastructure;
using SocialEvents.Data.Repositories;
using SocialEvents.Model;
using System.Collections.Generic;
using System.Linq;

namespace SocialEvents.Service
{
    // operations you want to expose
    public interface IDepartmentService:IServiceBase<Department>
    {

    }

    public class DepartmentService :ServiceBase<Department>, IDepartmentService
    {
        private readonly IDepartmentRepository DepartmentRepository;

        public DepartmentService(IRepository<Department> repository, IDepartmentRepository DepartmentRepository, IUnitOfWork unitOfWork)
            :base(repository,unitOfWork)
        {
            this.DepartmentRepository = DepartmentRepository;
        }


        #region IDepartmentService Members


        #endregion IDepartmentService Members
    }
}