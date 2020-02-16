using SocialEvents.MobileApi.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SocialEvents.MobileApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //#if DEBUG
            //            AreaRegistration.RegisterAllAreas();
            //#endif
            ApplyJsonFormatOnly();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            log4net.Config.XmlConfigurator.Configure();

        }


        protected void ApplyJsonFormatOnly()
        {
            GlobalConfiguration.Configuration.Formatters.Clear();
            GlobalConfiguration.Configuration.Formatters.Add(new JsonMediaTypeFormatter());
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            Log.Error(ex.Message, ex);
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "CEO WebApi";
                eventLog.WriteEntry(ex.Message, EventLogEntryType.Error, 2030, 3);
            }


        }
    }
}
