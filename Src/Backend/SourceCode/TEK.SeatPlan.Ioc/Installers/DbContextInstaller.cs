using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;

using Microsoft.EntityFrameworkCore;
using TEK.SeatPlan.ResourceAccess;

namespace TEK.SeatPlan.Ioc.Installers
{
	internal class DbContextInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			Common.Requires.ArgumentNotNull(container, "container");

			container.Register
			(
				Component.For<DbContext>().ImplementedBy<DataContext>().LifeStyle.PerWebRequest
			);
		}
	}
}