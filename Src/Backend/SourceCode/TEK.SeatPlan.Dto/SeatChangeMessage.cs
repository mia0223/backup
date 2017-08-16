using System;
using System.Collections.Generic;

namespace TEK.SeatPlan.Dto
{
	public class SeatChangeMessage
	{
		public string From { get; set; }

		public string To { get; set; }

		public string CC { get; set; }

		public string Subject { get; set; }

		public string Body { get; set; }

	    public string MoveDate { get; set; }

	    public string ContentSection1 { get; set; }

	    public string ContentSection2 { get; set; }


        public IEnumerable<SeatChangeLog> SeatChangeLog { get; set; }
	}
}