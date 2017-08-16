using Castle.Windsor;
using Castle.MicroKernel.ModelBuilder;

using TEK.SeatPlan.Common;
using TEK.SeatPlan.Ioc.Installers;

namespace TEK.SeatPlan.Ioc
{
	public static class BootStrapper
	{
		public static IWindsorContainer Configure(IWindsorContainer container)
		{
			return BootStrapper.Configure(container, null);
		}

		public static IWindsorContainer Configure(
			IWindsorContainer container,
			IContributeComponentModelConstruction contributor)
		{
			Requires.ArgumentNotNull(container, "container");

			if (contributor != null)
			{
				container.Kernel.ComponentModelBuilder.AddContributor(contributor);
			}

			container
				.Install(new DbContextInstaller())
				.Install(new RepositoryInstaller())
				.Install(new DataServiceInstaller())
                .Install(new ComponentInstaller());

			return container;
		}
	}
}