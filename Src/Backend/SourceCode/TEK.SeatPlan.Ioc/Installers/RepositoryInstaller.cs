using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;

using TEK.SeatPlan.ResourceAccess;
using TEK.SeatPlan.ResourceAccess.Contract;

namespace TEK.SeatPlan.Ioc.Installers
{
	internal class RepositoryInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			Common.Requires.ArgumentNotNull(container, "container");

			container.Register(Component
				.For(typeof(IRepository<>))
				.ImplementedBy(typeof(Repository<>))
				.LifeStyle.PerWebRequest);
		}
	}
}