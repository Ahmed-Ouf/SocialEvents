using SocialEvents.Data.Infrastructure;
using SocialEvents.Data.Repositories;
using SocialEvents.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialEvents.Service
{
    // operations you want to expose
    public interface ILoginAuditService : IServiceBase<LoginAudit>
    {
 
    }

    public class LoginAuditService : ServiceBase<LoginAudit>, ILoginAuditService
    {
        private readonly ILoginAuditRepository LoginAuditRepository;

        public LoginAuditService(IRepository<LoginAudit> repository, ILoginAuditRepository LoginAuditRepository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            this.LoginAuditRepository = LoginAuditRepository;
        }

        #region ILoginAuditService Members


        #endregion ILoginAuditService Members
    }
}