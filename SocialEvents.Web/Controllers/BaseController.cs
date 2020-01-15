using System.Web.Mvc;

namespace SocialEvents.Web.Controllers
{
    public class BaseController : Controller
    {
        public AutoMapper.IMapper Mapper;

        public BaseController()
        {
            //Configure AutoMapper
            Mapper = Mapper ?? MvcApplication.MapperConfiguration.CreateMapper();
        }
    }
}