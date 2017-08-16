using Castle.Core.Logging;

namespace TEK.SeatPlan.BusinessLogic
{
	public abstract class DataComponentBase
	{
		public ILogger Logger { get; set; }

		protected DataComponentBase()
		{
			this.Logger = NullLogger.Instance;
		}
	}
}