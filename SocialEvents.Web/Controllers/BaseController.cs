using SocialEvents.Web.Helpers;
using System;
using System.Threading;
using System.Web;
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

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string cultureName = null;

            // Attempt to read the culture cookie from Request
            HttpCookie cultureCookie = Request.Cookies["_culture"];
            if (cultureCookie != null)
                cultureName = cultureCookie.Value;
            else
                cultureName = Request.UserLanguages != null && Request.UserLanguages.Length > 0 ?
                        Request.UserLanguages[0] :  // obtain it from HTTP header AcceptLanguages
                        null;
            // Validate culture name
            cultureName = CultureHelper.GetImplementedCulture(cultureName); // This is safe

            // Modify current thread's cultures
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            //SessionRolesHelper.FillSessionWithSacabUserRoles(System.Web.HttpContext.Current, sacabHandler);
            return base.BeginExecuteCore(callback, state);
        }

        public ActionResult SetCulture(string culture, string url)
        {
            // Validate input
            culture = CultureHelper.GetImplementedCulture(culture);
            // Save culture in a cookie
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
                cookie.Value = culture;   // update cookie value
            else
            {
                cookie = new HttpCookie("_culture");
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return Redirect(url);
        }
    }
}