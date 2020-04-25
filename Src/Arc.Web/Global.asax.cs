using Arc.Application;
using Arc.Infrastructure;
using Autofac;
using Autofac.Integration.Mvc;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Arc.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            var _builder = new ContainerBuilder()
                .AddApplication()
                .AddInfrastructure();

            _builder.RegisterControllers(typeof(MvcApplication).Assembly);

            var _container = _builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(_container));
        }
    }
}
