using System.ComponentModel.DataAnnotations;

namespace TEK.SeatPlan.Dto
{
	public class Seat
	{
		public int Id { get; set; }

		[Required]
		public int Number { get; set; }

		[StringLength(255)]
		public string Description { get; set; }

		[Required]
		public int Row { get; set; }

		[Required]
		public int Col { get; set; }

		[Required]
		public bool Transit { get; set; }

		[Required]
		public int LocationId { get; set; }

		public Employee Employee { get; set; }
	}
}