using Autofac;
using Autofac.Integration.Wcf;
using AutoMapper;
using SocialEvents.Data.Infrastructure;
using SocialEvents.Data.Repositories;
using SocialEvents.Service;
using SocialEvents.WCFService.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace SocialEvents.WCFService
{
    public class Global : System.Web.HttpApplication
    {

        
        protected void Application_Start(object sender, EventArgs e)
        {
            //AoutoMapper
            IMapper mapper = Mapping.Init();


            var builder = new ContainerBuilder();

            // Register your service implementations.
            builder.RegisterInstance(mapper).As<IMapper>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerLifetimeScope();

            // Repositories
            builder.RegisterAssemblyTypes(typeof(CategoryRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerLifetimeScope();
           
            // Services
            builder.RegisterAssemblyTypes(typeof(CategoryService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerLifetimeScope();

            // WCFServices
            builder.RegisterType<AnnouncementWCFService>();
            builder.RegisterType<CategoryWCFService>();
            builder.RegisterType<EventWCFService>();
            
            // Set the dependency resolver.
            var container = builder.Build();
            AutofacHostFactory.Container = container;
            log4net.Config.XmlConfigurator.Configure();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            Log.Error(ex.Message, ex);


            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "SocialEvents WCF Service";
                eventLog.WriteEntry(ex.Message, EventLogEntryType.Error);
            }
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}