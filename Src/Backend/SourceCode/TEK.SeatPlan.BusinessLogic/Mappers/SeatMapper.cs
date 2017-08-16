using System.Linq;
using System.Collections.Generic;

namespace TEK.SeatPlan.BusinessLogic.Mappers
{
	public static class SeatMapper
	{
		public static Dto.Seat ToDto(this Entity.Seat seatEntity)
		{
			return ToDto(seatEntity, true);
		}

		public static Dto.Seat ToDto(this Entity.Seat seatEntity, bool deepMapping)
		{
			if (seatEntity == null) return null;

			var dto = new Dto.Seat
			{
				Id = seatEntity.Id,
				Number = seatEntity.Number,
				Col = seatEntity.Col,
				Row = seatEntity.Row,
				Description = seatEntity.Description,
				Transit = seatEntity.Transit,
				LocationId = seatEntity.LocationId
			};

			if (deepMapping)
			{
				dto.Employee = seatEntity.Employee?.ToDto();
			}

			return dto;
		}

		public static Entity.Seat ToEntity(this Dto.Seat seatDto, Entity.Seat seatEntity)
		{
			if (seatDto == null) return null;

			seatEntity = seatEntity ?? new Entity.Seat();

			seatEntity.Id = seatDto.Id;
			seatEntity.Number = seatDto.Number;
			seatEntity.Col = seatDto.Col;
			seatEntity.Row = seatDto.Row;
			seatEntity.Description = seatDto.Description;
			seatEntity.Transit = seatDto.Transit;
			seatEntity.LocationId = seatDto.LocationId;
			seatEntity.Employee = seatDto.Employee?.ToEntity(seatEntity.Employee);
		    seatEntity.EmployeeId = seatDto.Employee?.Id;

            return seatEntity;
		}

		public static ICollection<Dto.Seat> ToDto(this IEnumerable<Entity.Seat> seatEntities)
		{
			return seatEntities?.Select(ta => ta.ToDto()).ToList();
		}
	}
}