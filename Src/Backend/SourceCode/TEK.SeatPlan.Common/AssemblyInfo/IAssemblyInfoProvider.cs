using System;

namespace TEK.SeatPlan.Common.AssemblyInfo
{
    public interface IAssemblyInfoProvider
    {
        string GetExecutingAssemblyLocation();
        Version GetExecutingAssemblyVersion();
        string GetProductVersion(string location);
    }
}