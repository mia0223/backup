using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Tek.SeatPlan.ResourceGateway
{
   public interface IRepository<T>
   {
      T Insert(T entity);
      T Delete(T entity);
      T Update(T entity);
      List<T> SearchFor(Expression<Func<T, bool>> predicate);
      List<T> GetAll();
   }
}
