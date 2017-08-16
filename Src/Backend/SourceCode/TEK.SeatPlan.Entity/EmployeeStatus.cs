using System;
using System.Collections.Generic;

namespace TEK.SeatPlan.Entity
{
	public class EmployeeStatus : TrackedEntity
	{
		public string Name { get; set; }

		public virtual ICollection<Employee> Employee { get; set; }
	}
}