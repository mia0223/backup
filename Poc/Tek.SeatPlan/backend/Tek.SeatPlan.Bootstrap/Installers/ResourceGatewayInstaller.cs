using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Tek.SeatPlan.ResourceGateway;

namespace Tek.SeatPlan.Bootstrap.Installers
{
   public class ResourceGatewayInstaller : IWindsorInstaller
   {
      public void Install(IWindsorContainer container, IConfigurationStore store)
      {
         container.Register(
            Classes
               .FromAssemblyContaining(typeof(SeatPlanDbContext))
               .BasedOn<IDbContext>()
               .WithServiceDefaultInterfaces()
               .LifestylePerWebRequest());

         container.Register(
            Classes.FromAssemblyContaining(typeof(Repository<>))
               .Where(t => !t.GetInterfaces().Contains(typeof(IDbContext)))
               .WithServiceDefaultInterfaces()
               .LifestyleTransient()
         );
      }
   }
}
