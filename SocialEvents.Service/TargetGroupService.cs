using SocialEvents.Data.Infrastructure;
using SocialEvents.Data.Repositories;
using SocialEvents.Model;
using System.Collections.Generic;
using System.Linq;

namespace SocialEvents.Service
{
    // operations you want to expose
    public interface ITargetGroupService:IServiceBase<TargetGroup>
    {

    }

    public class TargetGroupService :ServiceBase<TargetGroup>, ITargetGroupService
    {
        private readonly ITargetGroupRepository TargetGroupRepository;
        public TargetGroupService(IRepository<TargetGroup> repository, ITargetGroupRepository TargetGroupRepository, IUnitOfWork unitOfWork)
            :base(repository,unitOfWork)
        {
            this.TargetGroupRepository = TargetGroupRepository;
        }


        #region ITargetGroupService Members


        #endregion ITargetGroupService Members
    }
}