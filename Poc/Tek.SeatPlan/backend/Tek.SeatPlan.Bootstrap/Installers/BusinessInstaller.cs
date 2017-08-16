using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Tek.SeatPlan.Business;

namespace Tek.SeatPlan.Bootstrap.Installers
{
   public class BusinessInstaller : IWindsorInstaller
   {
      public void Install(IWindsorContainer container, IConfigurationStore store)
      {
         container.Register(
            Classes
            .FromAssemblyContaining(typeof(SimpleObjectLogic))
            .Pick()
            .WithServiceDefaultInterfaces()
            .LifestyleTransient());
      }
   }
}