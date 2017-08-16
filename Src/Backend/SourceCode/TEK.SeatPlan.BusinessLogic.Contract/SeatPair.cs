using TEK.SeatPlan.Entity;

namespace TEK.SeatPlan.BusinessLogic
{
	public class SeatPair
	{
		public readonly Seat Source;

		public readonly Seat Target;

		public SeatPair(Seat source, Seat target)
		{
			this.Source = source;
			this.Target = target;
		}
	}
}