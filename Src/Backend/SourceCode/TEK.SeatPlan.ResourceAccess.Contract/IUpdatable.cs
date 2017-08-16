namespace TEK.SeatPlan.ResourceAccess.Contract
{
	public interface IUpdatable<TEntity> where TEntity : class
	{
		TEntity Update(TEntity entity);
	}
}