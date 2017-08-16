using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;

using TEK.SeatPlan.BusinessLogic;
using TEK.SeatPlan.BusinessLogic.Contract;

namespace TEK.SeatPlan.Ioc.Installers
{
	internal class DataServiceInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			Common.Requires.ArgumentNotNull(container, "container");

			container.Register(Component
				.For<IAccessLogger>()
				.ImplementedBy<AccessLogger>()
				.LifeStyle.PerWebRequest);

			container.Register(Component
				.For(typeof(IDataService<>))
				.ImplementedBy(typeof(DataService<>))
				.LifeStyle.PerWebRequest);

			container.Register(
				Types.FromAssemblyContaining<DataComponentBase>()
				.BasedOn<DataComponentBase>()
				.WithServiceFirstInterface()
				.LifestylePerWebRequest());
		}
	}
}