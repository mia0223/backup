using System.ComponentModel.DataAnnotations;

namespace TEK.SeatPlan.Dto
{
	public class SeatPair
	{
		[Required]
		public int SourceSeatNumber { get; set; }

		[Required]
		public int TargetSeatNumber { get; set; }
	}
}