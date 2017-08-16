using System.Collections.Generic;
using TEK.SeatPlan.Entity;

namespace TEK.SeatPlan.BusinessLogic.Contract
{
    public interface IProjectColorPairComponent
    {
        IEnumerable<ProjectColorPair> Get();
    }
}