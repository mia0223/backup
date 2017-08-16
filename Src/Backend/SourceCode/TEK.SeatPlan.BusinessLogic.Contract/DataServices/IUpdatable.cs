namespace TEK.SeatPlan.BusinessLogic.Contract
{
	public interface IUpdatable<TEntity> where TEntity : class
	{
		TEntity Update(TEntity entity);
	}
}