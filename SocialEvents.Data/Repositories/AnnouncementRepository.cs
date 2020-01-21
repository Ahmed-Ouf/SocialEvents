using SocialEvents.Data.Infrastructure;
using SocialEvents.Model;
using System;
using System.Linq;

namespace SocialEvents.Data.Repositories
{
    public class AnnouncementRepository : RepositoryBase<Announcement>, IAnnouncementRepository
    {
        public AnnouncementRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

      

    }

    public interface IAnnouncementRepository : IRepository<Announcement>
    {

    }
}