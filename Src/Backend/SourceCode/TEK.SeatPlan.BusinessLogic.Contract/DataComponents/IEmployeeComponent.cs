using System.Collections.Generic;

namespace TEK.SeatPlan.BusinessLogic.Contract
{
	public interface IEmployeeComponent
	{
		Dto.Employee GetEmployee(int id);

		IEnumerable<Dto.Employee> GetEmployee();

		Dto.Employee CreateEmployee(Dto.Employee employee);

        Dto.Employee SoftDeleteEmployee(int employeeId);

		Dto.Employee UpdateEmployee(Dto.Employee employee);
	}
}