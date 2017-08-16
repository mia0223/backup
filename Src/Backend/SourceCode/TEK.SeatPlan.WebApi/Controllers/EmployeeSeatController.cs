using TEK.SeatPlan.BusinessLogic.Contract;
using TEK.SeatPlan.BusinessLogic.Mappers;

namespace TEK.SeatPlan.WebApi.Controllers
{
	public class EmployeeSeatController : BaseController
	{
		private readonly IEmployeeSeatComponent employeeSeatComponent;

		public EmployeeSeatController(IEmployeeSeatComponent employeeSeatComponent)
		{
			this.employeeSeatComponent = employeeSeatComponent;
		}

		public Dto.Seat Get(int id)
		{
			return this.employeeSeatComponent.GetSeatByEmployeeId(id)?.ToDto();
		}

		public Dto.EmployeeSeatProject Put(Dto.EmployeeSeatProject employeeSeatProject)
		{
			return this.employeeSeatComponent.UpdateEmployeeSeatProject(employeeSeatProject);
		}
	}
}