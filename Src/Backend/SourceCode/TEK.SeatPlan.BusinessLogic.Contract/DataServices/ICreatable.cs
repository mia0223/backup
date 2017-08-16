using System;
using System.Linq.Expressions;

using TEK.SeatPlan.Entity;

namespace TEK.SeatPlan.BusinessLogic.Contract
{
	public interface ICreatable<TEntity> where TEntity : class
	{
		TEntity Add(TEntity entity);

		BaseEntity Attach(BaseEntity entity);

		void Set<TValue, T>(object entity, Expression<Func<T>> propertyExpression, TValue propertyValue);
	}
}