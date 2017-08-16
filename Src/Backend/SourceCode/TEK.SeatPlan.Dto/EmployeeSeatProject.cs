using System.ComponentModel.DataAnnotations;

namespace TEK.SeatPlan.Dto
{
	public class EmployeeSeatProject
	{
		[Required]
		public int EmployeeId { get; set; }

		[Required]
		public int ProjectId { get; set; }

		[Required]
		public int TargetSeatNumber { get; set; }

		[Required]
		public string ConcurrentEmployeeName { get; set; }

		[Required]
		public bool FirstTry { get; set; }

		public bool Completed { get; set; }
	}
}