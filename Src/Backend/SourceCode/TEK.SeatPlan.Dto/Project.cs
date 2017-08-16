using System.ComponentModel.DataAnnotations;

namespace TEK.SeatPlan.Dto
{
	public class Project
	{
		[Required]
		public int Id { get; set; }

		[Required]
		[StringLength(55)]
		public string Name { get; set; }

		[StringLength(255)]
		public string Description { get; set; }

	    [StringLength(55)]
	    public string TechnicalServiceManager { get; set; }

        [Required]
		public bool Active { get; set; }

		[Required]
		public bool Internal { get; set; }

		public string BackgroundColor { get; set; }

		public string ForegroundColor { get; set; }
	}
}