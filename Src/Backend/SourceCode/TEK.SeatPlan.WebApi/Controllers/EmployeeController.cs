using System;
using System.Linq;
using System.Collections.Generic;

using TEK.SeatPlan.BusinessLogic.Mappers;
using TEK.SeatPlan.BusinessLogic.Contract;

namespace TEK.SeatPlan.WebApi.Controllers
{
    public class EmployeeController : BaseController
    {
	    private readonly IEmployeeComponent employeeComponent;

	    public EmployeeController(IEmployeeComponent employeeComponent)
	    {
		    this.employeeComponent = employeeComponent;
	    }

		public Dto.Employee Get(int id)
        {
			return employeeComponent.GetEmployee(id);
		}

	    public  IEnumerable<Dto.Employee> Get()
	    {
			return this.employeeComponent.GetEmployee();
	    }

		public Dto.Employee Post(Dto.Employee employee)
		{			
			return this.employeeComponent.CreateEmployee(employee);
	    }

		public Dto.Employee Put(Dto.Employee employeeDto)
		{
			return this.employeeComponent.UpdateEmployee(employeeDto);
		}

        public Dto.Employee Delete(int id)
        {
            return this.employeeComponent.SoftDeleteEmployee(id); 
        }
    }
}