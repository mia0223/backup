using System;
using System.ComponentModel.DataAnnotations;

namespace TEK.SeatPlan.Entity
{
	public class SeatChangeLog : BaseEntity
	{
		[Required]
		public DateTime ActionDate { get; set; }

		public Employee Employee { get; set; }

		public Seat SourceSeat { get; set; }

		public Seat TargetSeat { get; set; }

		public bool MailSent { get; set; }
	}
}