using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Linq;
using System.Reflection;
using Tek.SeatPlan.Models;

namespace Tek.SeatPlan.ResourceGateway
{
   public class SeatPlanDbContext : DbContext, IDbContext
   {

      protected override void OnModelCreating(ModelBuilder builder)
      {
         var allEntityTypes = Assembly.GetAssembly(typeof(BaseEntity)).GetTypes()
            .Where(type => type.IsSubclassOf(typeof(BaseEntity)) && (!type.IsAbstract));

         foreach (var entityType in allEntityTypes)
         {
            builder.Entity(entityType);
         }

         base.OnModelCreating(builder);
      }

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
         optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["SeatPlanDatabase"].ConnectionString);
      }

      public IQueryable<TEntity> GetReadOnly<TEntity>() where TEntity : class
      {
         return Set<TEntity>().AsNoTracking();
      }

      public IQueryable<TEntity> GetTracked<TEntity>() where TEntity : class
      {
         return Set<TEntity>();
      }


   }


}
