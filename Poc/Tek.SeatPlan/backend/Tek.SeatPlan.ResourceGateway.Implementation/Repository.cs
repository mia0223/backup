using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Tek.SeatPlan.ResourceGateway
{
   public class Repository<T> : IRepository<T> where T : class
   {
      private readonly IDbContext _dbContext;

      public Repository(IDbContext dbContext)
      {
         _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
      }

      public T Insert(T entity)
      {
         var e = _dbContext.Add(entity);
         _dbContext.SaveChanges();
         return e.Entity;
      }

      public T Delete(T entity)
      {
         var e = _dbContext.Remove(entity);
         _dbContext.SaveChanges();
         return e.Entity;
      }

      public List<T> SearchFor(Expression<Func<T, bool>> predicate)
      {
         return _dbContext.GetReadOnly<T>().Where(predicate).ToList();
      }

      public List<T> GetAll()
      {
         return _dbContext.GetReadOnly<T>().ToList();
      }

      public T Update(T entity)
      {
         var e = _dbContext.Update(entity);
         _dbContext.SaveChanges();
         return e.Entity;
      }
   }
}
