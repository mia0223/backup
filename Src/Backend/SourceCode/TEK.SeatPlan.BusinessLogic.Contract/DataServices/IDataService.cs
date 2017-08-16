namespace TEK.SeatPlan.BusinessLogic.Contract
{
	public interface IDataService<TEntity> :
		ICreatable<TEntity>, IRetrievable<TEntity>, IUpdatable<TEntity>, IDeletable<TEntity>
		where TEntity : class
	{
	}
}