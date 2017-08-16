using TEK.SeatPlan.Entity;

namespace TEK.SeatPlan.BusinessLogic.Contract
{
    public interface IColorPickingComponent
    {
        ProjectColorPair GetNextAvailableColorForProject();
    }
}   