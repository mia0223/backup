using TEK.SeatPlan.Common;
using TEK.SeatPlan.Common.AssemblyInfo;
using TEK.SeatPlan.BusinessLogic.Contract;

namespace TEK.SeatPlan.BusinessLogic
{
    public class VersionComponent : IVersionComponent
    {
        private readonly IAssemblyInfoProvider assemblyInfoProvider;

        public VersionComponent(IAssemblyInfoProvider assemblyInfoProvider)
        {
            Requires.ArgumentNotNull(assemblyInfoProvider, nameof(assemblyInfoProvider));

			this.assemblyInfoProvider = assemblyInfoProvider;
        }

        public string GetVersion()
        {
            var location = this.assemblyInfoProvider.GetExecutingAssemblyLocation();

            if (!string.IsNullOrWhiteSpace(location))
            {
                return this.assemblyInfoProvider.GetProductVersion(location);
            }

            var version = this.assemblyInfoProvider.GetExecutingAssemblyVersion();

			return $"{version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
        }
    }
}