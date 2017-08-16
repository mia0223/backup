using System.ComponentModel.DataAnnotations;

namespace TEK.SeatPlan.Dto
{
	public class Employee
	{
		[Required]
		public int Id { get; set; }

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

		public Project Project { get; set; }

		public Seat Seat { get; set; }

		public EmployeeStatus Status { get; set; }
	}
}