using System.Linq;
using System.Collections.Generic;

namespace TEK.SeatPlan.BusinessLogic.Mappers
{
	public static class EmployeeStatusMapper
	{
		public static Dto.EmployeeStatus ToDto(this Entity.EmployeeStatus employeeStatusEntity)
		{
			if (employeeStatusEntity == null) return null;

			return new Dto.EmployeeStatus { Id = employeeStatusEntity.Id, Name = employeeStatusEntity.Name };
		}

		public static Entity.EmployeeStatus ToEntity(
			this Dto.EmployeeStatus employeeStatusDto, Entity.EmployeeStatus employeeStatusEntity)
		{
			if (employeeStatusDto == null) return null;

			employeeStatusEntity = employeeStatusEntity ?? new Entity.EmployeeStatus();

			employeeStatusEntity.Id = employeeStatusDto.Id;
			employeeStatusEntity.Name = employeeStatusDto.Name;

			return employeeStatusEntity;
		}

		public static ICollection<Dto.EmployeeStatus> ToDto(this IEnumerable<Entity.EmployeeStatus> entities)
		{
			return entities?.Select(ta => ta.ToDto())?.ToList();
		}
	}
}