using System.Linq;
using System.Collections.Generic;

namespace TEK.SeatPlan.BusinessLogic.Mappers
{
	public static class LocationMapper
	{
		public static Dto.Location ToDto(this Entity.Location locationEntity)
		{
			if (locationEntity == null) return null;

			return new Dto.Location
			{
				Id = locationEntity.Id,
				Name = locationEntity.Name,
				Cols = locationEntity.Cols,
				Rows = locationEntity.Rows,
				FloorLevel = locationEntity.FloorLevel			
			};
		}

		public static Entity.Location ToEntity(this Dto.Location locationDto, Entity.Location locationEntity)
		{
			if (locationDto == null) return null;

			locationEntity = locationEntity ?? new Entity.Location();

			locationEntity.Id = locationDto.Id;
			locationEntity.Name = locationDto.Name;
			locationEntity.Cols = locationDto.Cols;
			locationEntity.Rows = locationDto.Rows;
			locationEntity.FloorLevel = locationDto.FloorLevel;

			return locationEntity;
		}

		public static ICollection<Dto.Location> ToDto(this IEnumerable<Entity.Location> locationEntities)
		{
			return locationEntities?.Select(ta => ta.ToDto()).ToList();
		}
	}
}