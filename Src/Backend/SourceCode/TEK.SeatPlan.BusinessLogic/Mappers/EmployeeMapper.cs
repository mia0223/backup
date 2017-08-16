using System.Linq;
using System.Collections.Generic;

namespace TEK.SeatPlan.BusinessLogic.Mappers
{
	public static class EmployeeMapper
	{
		public static Dto.Employee ToDto(this Entity.Employee employeeEntity)
		{
			if (employeeEntity == null) return null;

			return new Dto.Employee
			{
				Id = employeeEntity.Id,
				FirstName = employeeEntity.FirstName,
				LastName = employeeEntity.LastName,
				Email = employeeEntity.Email,
				Description = employeeEntity.Description,				
				Status = employeeEntity.Status?.ToDto(),
				Project = employeeEntity.Project?.ToDto(),
				Seat = employeeEntity.Seat?.ToDto(false)
			};
		}

		public static Entity.Employee ToEntity(this Dto.Employee employeeDto, Entity.Employee employeeEntity)
		{
			if (employeeDto == null) return null;

			employeeEntity = employeeEntity ?? new Entity.Employee();

			employeeEntity.Id = employeeDto.Id;
			employeeEntity.FirstName = employeeDto.FirstName;
			employeeEntity.LastName = employeeDto.LastName;
			employeeEntity.Email = employeeDto.Email;
			employeeEntity.Description = employeeDto.Description;
			employeeEntity.Status = employeeDto.Status.ToEntity(employeeEntity.Status);
			employeeEntity.Project = employeeDto.Project.ToEntity(employeeEntity.Project);
			employeeEntity.Seat = employeeDto.Seat.ToEntity(employeeEntity.Seat);

			return employeeEntity;
		}

		public static ICollection<Dto.Employee> ToDto(this IEnumerable<Entity.Employee> employeeEntities)
		{
			return employeeEntities?.Select(ta => ta.ToDto()).ToList();
		}
	}
}