using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Web.Http;
using Tek.SeatPlan.Controllers;

namespace Tek.SeatPlan.Bootstrap.Installers
{
   public class ControllersInstaller : IWindsorInstaller
   {
      public void Install(IWindsorContainer container, IConfigurationStore store)
      {
         container.Register(
            Classes
               .FromAssemblyContaining(typeof(SimpleObjectController))
               .BasedOn<ApiController>()
               .WithServiceDefaultInterfaces()
               .LifestylePerWebRequest());
      }
   }
}