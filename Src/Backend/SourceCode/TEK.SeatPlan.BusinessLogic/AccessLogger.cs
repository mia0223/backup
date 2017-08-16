using System.Linq;
using System.Text;
using System.Threading;
using Castle.Core.Logging;

using TEK.SeatPlan.BusinessLogic.Contract;

namespace TEK.SeatPlan.BusinessLogic
{
	public class AccessLogger : IAccessLogger
	{
		public ILogger Logger { get; set; }

		public AccessLogger()
		{
			this.Logger = NullLogger.Instance;
		}

		public void LogOperationResult(int changesCount, object entity, string operation)
		{
			if (entity == null) return;

			Logger.InfoFormat("{0} entities {1} by user: {2}\nRootType: {3}, details: {4}",
				changesCount,
				operation,
				Thread.CurrentPrincipal.Identity.Name,
				GetEntityType(entity),
				entity.ToString());
		}

		public string GetEntityType(object entity)
		{
			if (entity == null) return string.Empty;

			var entityTypeName = entity.GetType().Name;
		
			if (entityTypeName.Contains("_"))
			{
				entityTypeName = entityTypeName.Split('_').First();
			}

			return entityTypeName;
		}
	}
}