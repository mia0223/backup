using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using TEK.SeatPlan.Entity;
using RC = TEK.SeatPlan.ResourceAccess.Contract;
using BC = TEK.SeatPlan.BusinessLogic.Contract;

namespace TEK.SeatPlan.BusinessLogic
{
	public class DataService<TEntity> : BC.IDataService<TEntity> where TEntity : BaseEntity
	{
		private readonly BC.IAccessLogger logger;
		private readonly RC.IRepository<TEntity> repository;

		public DataService(RC.IRepository<TEntity> repository, BC.IAccessLogger logger)
		{
			this.repository = repository;
			this.logger = logger;
		}

		public TEntity Add(TEntity entity)
		{
			try
			{
				this.repository.Add(entity);
				var changesCount = this.repository.SaveChanges();
				this.logger.LogOperationResult(changesCount, entity, "created");

				return entity;
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException($"{entity} not created. Reason(s):{ex}", ex);
			}
		}

		public BaseEntity Attach(BaseEntity entity)
		{
			return this.repository.Attach(entity);
		}

		public TEntity Update(TEntity entity)
		{
			try
			{
				this.repository.Update(entity);
				var changesCount = this.repository.SaveChanges();
				this.logger.LogOperationResult(changesCount, entity, "updated");

				return entity;
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException($"{this.logger.GetEntityType(entity)} not updated. {entity}\nReason--->{ex}", ex);
			}
		}

		public TEntity Get(params object[] keyValues)
		{
			var result = this.repository.Get(keyValues);

			if (result != null)
			{
				this.logger.LogOperationResult(1, result, "retrieved");
			}

			return result;
		}

		public TEntity Get(Expression<Func<TEntity, bool>> predicate)
		{
			return this.Get(predicate, null);
		}

		public TEntity Get(Expression<Func<TEntity, bool>> predicate,
			params Expression<Func<TEntity, object>>[] include)
		{
			var result = this.repository.Get(predicate, include);

			if (result != null)
			{
				this.logger.LogOperationResult(1, result, "retrieved");
			}

			return result;
		}

		public IEnumerable<TEntity> Find(
			Expression<Func<TEntity, bool>> predicate,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy)
		{
			return this.Find(predicate, orderBy, null);
		}

		public IEnumerable<TEntity> Find(
			Expression<Func<TEntity, bool>> predicate,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
			params Expression<Func<TEntity, object>>[] include)
		{
			var result = this.repository.Find(predicate, orderBy, include);

			if (result != null)
			{
				this.logger.LogOperationResult(result.Count(), result.FirstOrDefault(), "retrieved");
			}

			return result;
		}

		public TEntity Delete(TEntity entity)
		{
			try
			{
				var oldEntity = this.repository.Delete(entity);
				var changesCount = this.repository.SaveChanges();
				this.logger.LogOperationResult(changesCount, entity, "deleted");

				return oldEntity;
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException(
					$"{entity.GetType().Name} not deleted. {entity}\nReason--->{ex}", ex);
			}
		}

		public void Set<TValue, T>(object entity, Expression<Func<T>> propertyExpression, TValue propertyValue)
		{
			this.repository.Set(entity, propertyExpression, propertyValue);
		}
	}
}