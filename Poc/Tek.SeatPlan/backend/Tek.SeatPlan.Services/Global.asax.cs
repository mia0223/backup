using System.Web.Http;

namespace Tek.SeatPlan.Services
{
   public class WebApiApplication : System.Web.HttpApplication
   {
      protected void Application_Start()
      {
         GlobalConfiguration.Configuration.DependencyResolver = Bootstrap.Bootstrap.ConfigureDependencyResolver();
         GlobalConfiguration.Configure(WebApiConfig.Register);
      }
   }
}
