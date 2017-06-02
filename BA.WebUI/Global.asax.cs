using AutoMapper;
using BA.WebUI.App_Start;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BA.WebUI.AutoMapper;

namespace BA.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Mapper.Initialize(c => c.AddProfile<DTOtoViewModelMapper>());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
