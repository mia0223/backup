using System;

namespace TEK.SeatPlan.Dto
{
	public class SeatChangeLog
	{
		public int Id { get; set; }

		public Employee Employee { get; set; }

		public Seat SourceSeat { get; set; }

		public Seat TargetSeat { get; set; }

		public bool Selected { get; set; }

		public bool MailSent { get; set; }
	}
}