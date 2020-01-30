using Autofac;
using SocialEvents.Data.Infrastructure;
using SocialEvents.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SocialEvents.WCFService.AppStart
{
    //public static class Bootstrapper
    //{
    //    public static void Run()
    //    {
    //        SetAutofacContainer();
    //    }

    //    private static void SetAutofacContainer()
    //    {
    //        var builder = new ContainerBuilder();
    //        builder.RegisterControllers(Assembly.GetExecutingAssembly());
    //        builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
    //        builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

    //        // Repositories
    //        builder.RegisterAssemblyTypes(typeof(CategoryRepository).Assembly)
    //            .Where(t => t.Name.EndsWith("Repository"))
    //            .AsImplementedInterfaces().InstancePerRequest();
    //        // Services
    //        builder.RegisterAssemblyTypes(typeof(CategoryService).Assembly)
    //           .Where(t => t.Name.EndsWith("Service"))
    //           .AsImplementedInterfaces().InstancePerRequest();

    //        IContainer container = builder.Build();
    //        DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
    //    }
    //}
}
