using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;

using TEK.SeatPlan.BusinessLogic;
using TEK.SeatPlan.BusinessLogic.Contract;
using TEK.SeatPlan.Common.AssemblyInfo;

namespace TEK.SeatPlan.Ioc.Installers
{
	internal class ComponentInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			Common.Requires.ArgumentNotNull(container, "container");

            container.Register(Component
		        .For(typeof(IAssemblyInfoProvider))
		        .ImplementedBy(typeof(AssemblyInfoProvider))
		        .LifeStyle.PerWebRequest);

			container.Register(Component
				.For(typeof(IVersionComponent))
				.ImplementedBy(typeof(VersionComponent))
				.LifeStyle.PerWebRequest);
		}
	}
}