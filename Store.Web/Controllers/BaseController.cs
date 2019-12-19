using Store.Web.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Web.Controllers
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