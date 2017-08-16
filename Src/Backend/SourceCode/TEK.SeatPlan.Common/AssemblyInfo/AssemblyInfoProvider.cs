using System;
using System.Reflection;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace TEK.SeatPlan.Common.AssemblyInfo
{
    [ExcludeFromCodeCoverage]
    public class AssemblyInfoProvider : IAssemblyInfoProvider
    {
        public string GetExecutingAssemblyLocation()
        {
            return Assembly.GetExecutingAssembly().Location ?? string.Empty;
        }

        public Version GetExecutingAssemblyVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version;
        }

        public string GetProductVersion(string location)
        {
            return FileVersionInfo.GetVersionInfo(location).ProductVersion;
        }
    }
}