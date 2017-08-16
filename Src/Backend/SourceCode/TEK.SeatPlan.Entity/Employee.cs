using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TEK.SeatPlan.Entity
{
	public class Employee : TrackedEntity
	{
		[Required]
		[StringLength(55)]
		public string FirstName { get; set; }

		[Required]
		[StringLength(55)]
		public string LastName { get; set; }

		[Required]
		[StringLength(55)]
		public string Email { get; set; }

		[StringLength(255)]
		public string Description { get; set; }

		[Required]
		public bool Active { get; set; }

		public virtual Project Project { get; set; }

		public virtual Seat Seat { get; set; }

		public virtual EmployeeStatus Status { get; set; }

		public virtual ICollection<SeatChangeLog> SeatChangeLog { get; set; }
	}
}