using SocialEvents.Data.Infrastructure;
using SocialEvents.Data.Repositories;
using SocialEvents.Model;
using System.Collections.Generic;
using System.Linq;

namespace SocialEvents.Service
{
    // operations you want to expose
    public interface ILocationService:IServiceBase<Location>
    {

    }

    public class LocationService :ServiceBase<Location>, ILocationService
    {
        private readonly ILocationRepository LocationRepository;

        public LocationService(IRepository<Location> repository, ILocationRepository LocationRepository, IUnitOfWork unitOfWork)
            :base(repository,unitOfWork)
        {
            this.LocationRepository = LocationRepository;
        }

        #region ILocationService Members


        #endregion ILocationService Members
    }
}