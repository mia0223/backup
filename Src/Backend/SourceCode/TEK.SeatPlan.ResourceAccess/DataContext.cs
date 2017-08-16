using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

using TEK.SeatPlan.Entity;
using TEK.SeatPlan.Entity.Validate;

namespace TEK.SeatPlan.ResourceAccess
{
	public class DataContext : DbContextBase
	{
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			AddModelesToContext(modelBuilder);

			modelBuilder.Entity<Project>().HasIndex(c => c.Name).IsUnique();
			modelBuilder.Entity<Project>().Property(c => c.Active).HasDefaultValue(true);

			modelBuilder.Entity<Employee>().HasIndex(c => c.Email).IsUnique();
			modelBuilder.Entity<Employee>().Property(c => c.Active).HasDefaultValue(true);

			modelBuilder.Entity<Seat>().HasIndex(c => new { c.LocationId, c.Number }).IsUnique();
			modelBuilder.Entity<Seat>().Property(c => c.Row).HasDefaultValueSql("0");
			modelBuilder.Entity<Seat>().Property(c => c.Col).HasDefaultValueSql("0");
			modelBuilder.Entity<Seat>().Property(c => c.Active).HasDefaultValue(true);
			modelBuilder.Entity<Seat>().Property(c => c.Transit).HasDefaultValue(false);

			modelBuilder.Entity<Location>().HasIndex(c => c.Name).IsUnique();
			modelBuilder.Entity<Location>().Property(c => c.FloorLevel).HasDefaultValueSql("0");
			modelBuilder.Entity<Location>().Property(c => c.Rows).HasDefaultValueSql("50");
			modelBuilder.Entity<Location>().Property(c => c.Cols).HasDefaultValueSql("30");
			modelBuilder.Entity<Location>().Property(c => c.Active).HasDefaultValue(true);

			modelBuilder.Entity<SeatChangeLog>().HasOne(c => c.SourceSeat).WithMany(d => d.SourceSeatChangeLog);
			modelBuilder.Entity<SeatChangeLog>().HasOne(c => c.TargetSeat).WithMany(d => d.TargetSeatChangeLog);

			InitTrackingFields(modelBuilder);

			base.OnModelCreating(modelBuilder);
		}

		private static void InitTrackingFields(ModelBuilder modelBuilder)
		{
			foreach (var entityType in modelBuilder.Model.GetEntityTypes()
				.Where(e => typeof(TrackedEntity).IsAssignableFrom(e.ClrType)))
			{
				modelBuilder.Entity(entityType.ClrType).Property<DateTime>("DateCreated")
					.HasDefaultValueSql("GETDATE()")
					.IsRequired();

				modelBuilder.Entity(entityType.ClrType).Property<DateTime?>("DateModified");

				modelBuilder.Entity(entityType.ClrType).Property<string>("UserCreated")
					.HasMaxLength(64)
					.IsRequired();

				modelBuilder.Entity(entityType.ClrType).Property<string>("UserModified")
					.HasMaxLength(64);
			}
		}

		private static void AddModelesToContext(ModelBuilder modelBuilder)
		{
			var allEntityTypes = Assembly.GetAssembly(typeof(BaseEntity)).GetTypes()
				.Where(type => type.IsSubclassOf(typeof(BaseEntity)) && (!type.IsAbstract));

			foreach (var entityType in allEntityTypes)
			{
				modelBuilder.Entity(entityType);
			}
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (optionsBuilder.IsConfigured) return;

			optionsBuilder
				.UseSqlServer(ConfigurationManager.ConnectionStrings["SQLConnectionString"].ToString())
				.ConfigureWarnings(x => x.Ignore(RelationalEventId.AmbientTransactionWarning));
		}

		protected override IList<ValidationError> Validate()
		{
			var utcNow = DateTime.UtcNow;

			var userName = GetAuthenticatedUserName();

			var entities = this.ChangeTracker.Entries().Where(x =>
				x.State == EntityState.Added || x.State == EntityState.Modified);

			var validationErrors = new List<ValidationError>();

			foreach (var entityEntry in entities)
			{
				SetTrackingInfo(entityEntry, userName, utcNow);

				var validateError = Validator.Validate(entityEntry.Entity);

				if (validateError != null)
				{
					validationErrors.Add(validateError);
				}
			}

			return validationErrors;
		}

		private static void SetTrackingInfo(EntityEntry entityEntry, string userName, DateTime utcNow)
		{
			if (!(entityEntry.Entity is TrackedEntity)) return;

			if (entityEntry.State == EntityState.Added)
			{
				entityEntry.Property("DateCreated").CurrentValue = utcNow;
				entityEntry.Property("UserCreated").CurrentValue = userName;
			}
			else
			{
				entityEntry.Property("DateModified").CurrentValue = utcNow;
				entityEntry.Property("UserModified").CurrentValue = userName;
			}
		}

		private static string GetAuthenticatedUserName()
		{
			var userName = Thread.CurrentPrincipal.Identity.Name;

			if (string.IsNullOrEmpty(userName))
			{
				userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
			}

			return userName;
		}
	}
}