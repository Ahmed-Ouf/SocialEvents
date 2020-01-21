using AutoMapper;
using SocialEvents.Data;
using SocialEvents.Web.App_Start;
using SocialEvents.Web.Helpers;
using SocialEvents.Web.Mappings;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SocialEvents.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        internal static MapperConfiguration MapperConfiguration { get; private set; }

        protected void Application_Start()
        {
            // Init database
           // System.Data.Entity.Database.SetInitializer(new StoreSeedData());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Autofac and Automapper configurations
            Bootstrapper.Run();
            MapperConfiguration = AutoMapperConfiguration.Configure();
            // log error config
            log4net.Config.XmlConfigurator.Configure();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            var AjaxRequest = new HttpRequestWrapper(Request).IsAjaxRequest();
            Log.Error(ex.Message, ex);
            if (!AjaxRequest)
            {
#if DEBUG
                Console.WriteLine("Mode=Debug");
#else
 Response.Redirect("~/404.html");
#endif
            }
            //log the error!
        }
    }
}