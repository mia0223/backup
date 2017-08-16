using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TEK.SeatPlan.Dto
{
	public class Location
	{
		[Required]
		public int Id { get; set; }

		[Required]
		[StringLength(55)]
		public string Name { get; set; }

		public int FloorLevel { get; set; }

		[Required]
		public bool Active { get; set; }

		[Required]
		public int Rows { get; set; }

		[Required]
		public int Cols { get; set; }

		public Location ParentLocation { get; set; }

		public ICollection<Location> ChildLocations { get; set; }

		public ICollection<Seat> Seats { get; set; }
	}
}