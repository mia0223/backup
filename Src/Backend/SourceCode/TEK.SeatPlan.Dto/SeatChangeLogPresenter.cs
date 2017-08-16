using System;
using System.Collections.Generic;

namespace TEK.SeatPlan.Dto
{
	public class SeatChangeLogPresenter
	{
		public DateTime ActionDate { get; set; }

		public IEnumerable<SeatChangeLog> SeatChangeLog { get; set; }
	}
}