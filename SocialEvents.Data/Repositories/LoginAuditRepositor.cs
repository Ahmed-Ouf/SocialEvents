using SocialEvents.Data.Infrastructure;
using SocialEvents.Model;
using System;
using System.Linq;

namespace SocialEvents.Data.Repositories
{
    public class LoginAuditRepository : RepositoryBase<LoginAudit>, ILoginAuditRepository
    {
        public LoginAuditRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

      

    }

    public interface ILoginAuditRepository : IRepository<LoginAudit>
    {

    }
}