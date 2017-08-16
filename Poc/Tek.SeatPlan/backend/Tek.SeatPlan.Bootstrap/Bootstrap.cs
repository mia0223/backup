using System.Web.Http.Dependencies;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Tek.SeatPlan.Bootstrap.Resolvers;

namespace Tek.SeatPlan.Bootstrap
{
   public class Bootstrap
   {
      public static IDependencyResolver ConfigureDependencyResolver()
      {
         var container = new WindsorContainer();
         container.Install(FromAssembly.InThisApplication());
         return new WindsorDependencyResolver(container.Kernel);
      }
   }
}