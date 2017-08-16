using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TEK.SeatPlan.Entity
{
	public class Seat : TrackedEntity
	{
		[Required]
		public int Number { get; set; }

		[StringLength(255)]
		public string Description { get; set; }

		[Required]
		public bool Active { get; set; }

		[Required]
		public bool Transit { get; set; }

		[Required]
		public int Row { get; set; }

		[Required]
		public int Col { get; set; }

		[Required]
		public int LocationId { get; set; }

		public virtual Location Location { get; set; }

		public int? EmployeeId { get; set; }

		public virtual Employee Employee { get; set; }

		public virtual IEnumerable<SeatChangeLog> SourceSeatChangeLog { get; set; }

		public virtual IEnumerable<SeatChangeLog> TargetSeatChangeLog { get; set; }
	}
}