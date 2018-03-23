using Microsoft.Owin;
using Owin;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TestTaskWebApplication.Infrastructure.Config;
using TestTaskWebApplication.Models;
using DependencyResolver = TestTaskWebApplication.Infrastructure.DependencyResolver;

[assembly: OwinStartupAttribute(typeof(TestTaskWebApplication.Startup))]
namespace TestTaskWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Settings settings = Settings.GetSettings();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var resolver = new DependencyResolver();
            System.Web.Mvc.DependencyResolver.SetResolver(resolver);            

            ConfigureAuth(app, resolver);
        }
    }
}
