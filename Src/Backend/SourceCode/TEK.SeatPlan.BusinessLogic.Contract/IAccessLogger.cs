namespace TEK.SeatPlan.BusinessLogic.Contract
{
	public interface IAccessLogger
	{
		void LogOperationResult(int changesCount, object entity, string operation);

		string GetEntityType(object entity);
	}
}