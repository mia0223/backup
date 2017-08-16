namespace TEK.SeatPlan.BusinessLogic.Contract
{
	public interface IDeletable<TEntity> where TEntity : class
	{
		TEntity Delete(TEntity entity);
	}
}