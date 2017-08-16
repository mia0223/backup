using System;
using System.Linq;
using System.Collections.Generic;

namespace TEK.SeatPlan.BusinessLogic.Mappers
{
	public static class SeatChangeLogMapper
	{
		public static Dto.SeatChangeLog ToDto(this Entity.SeatChangeLog seatChangeLog)
		{
			if (seatChangeLog == null) return null;

			return new Dto.SeatChangeLog
			{
				Id = seatChangeLog.Id,
				Employee = seatChangeLog.Employee?.ToDto(),
				SourceSeat = seatChangeLog.SourceSeat?.ToDto(),
				TargetSeat = seatChangeLog.TargetSeat?.ToDto(),
				MailSent = seatChangeLog.MailSent
			};
		}

		public static ICollection<Dto.SeatChangeLog> ToDto(this IEnumerable<Entity.SeatChangeLog> entities)
		{
			return entities?.Select(ta => ta.ToDto()).ToList();
		}
	}
}