using System.Collections.Generic;
using cm = System.ComponentModel.DataAnnotations;

namespace TEK.SeatPlan.Entity.Validate
{
	public class ValidationError
	{
		public readonly string EntityName;

		public readonly IEnumerable<cm.ValidationResult> ValidationResults;

		public ValidationError(string entityName, IEnumerable<cm.ValidationResult> validationResults)
		{
			this.EntityName = entityName;
			this.ValidationResults = validationResults;
		}
	}
}