using System.Linq;
using System.Collections.Generic;

namespace TEK.SeatPlan.BusinessLogic.Mappers
{
	public static class ProjectMapper
	{
		public static Dto.Project ToDto(this Entity.Project projectEntity)
		{
			if (projectEntity == null) return null;

			return new Dto.Project
			{
				Id = projectEntity.Id,
				Name = projectEntity.Name,
				Description = projectEntity.Description,
				Active = projectEntity.Active,
				BackgroundColor = projectEntity.BackgroundColor,
				ForegroundColor = projectEntity.ForegroundColor,
				Internal = projectEntity.Internal,
                TechnicalServiceManager = projectEntity.TechnicalServiceManager
			};
		}

		public static Entity.Project ToEntity(this Dto.Project projectDto, Entity.Project projectEntity)
		{
			if (projectDto == null) return null;

			projectEntity = projectEntity ?? new Entity.Project();

			projectEntity.Id = projectDto.Id;
			projectEntity.Name = projectDto.Name;
			projectEntity.Description = projectDto.Description;
			projectEntity.Active = projectDto.Active;
			projectEntity.BackgroundColor = projectDto.BackgroundColor;
			projectEntity.ForegroundColor = projectDto.ForegroundColor;
			projectEntity.Internal = projectDto.Internal;
		    projectEntity.TechnicalServiceManager = projectDto.TechnicalServiceManager;

			return projectEntity;
		}

		public static ICollection<Dto.Project> ToDto(this IEnumerable<Entity.Project> projectEntities)
		{
			return projectEntities?.Select(ta => ta.ToDto())?.ToList();
		}
	}
}