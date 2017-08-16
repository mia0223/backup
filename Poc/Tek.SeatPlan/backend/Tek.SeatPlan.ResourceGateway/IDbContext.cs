using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Tek.SeatPlan.ResourceGateway
{
   public interface IDbContext
   {
      IQueryable<TEntity> GetReadOnly<TEntity>() where TEntity : class;
      IQueryable<TEntity> GetTracked<TEntity>() where TEntity : class;

      int SaveChanges();
      EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : class;
      EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class;
      EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class;
   }
}