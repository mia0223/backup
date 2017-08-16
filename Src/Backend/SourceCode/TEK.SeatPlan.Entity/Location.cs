using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEK.SeatPlan.Entity
{
	public class Location : TrackedEntity
	{
		[Required]
		[StringLength(55)]
		public string Name { get; set; }

		[Required]
		public int FloorLevel { get; set; }

		[Required]
		public bool Active { get; set; }

		[Required]
		public int Rows { get; set; }

		[Required]
		public int Cols { get; set; }

		public int? ParentId { get; set; }

		[ForeignKey("ParentId")]
		public virtual Location ParentLocation { get; set; }

		public virtual ICollection<Location> ChildLocations { get; set; }

		public virtual ICollection<Seat> Seats { get; set; }
	}
}