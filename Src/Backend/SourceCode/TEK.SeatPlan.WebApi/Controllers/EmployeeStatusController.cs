using System;
using System.Linq;
using System.Collections.Generic;

using TEK.SeatPlan.BusinessLogic.Contract;
using TEK.SeatPlan.BusinessLogic.Mappers;

namespace TEK.SeatPlan.WebApi.Controllers
{
	public class EmployeeStatusController : BaseController
	{
		private readonly IDataService<Entity.EmployeeStatus> dataService;

		public EmployeeStatusController(IDataService<Entity.EmployeeStatus> dataService)
		{
			this.dataService = dataService;
		}

		public IEnumerable<Dto.EmployeeStatus> Get()
		{
			return dataService.Find(x => x.Id > 0, null)?.ToDto();
		}

		public Dto.EmployeeStatus Get(int id)
		{
			return dataService.Get(x => x.Id == id, null)?.ToDto();
		}
	}
}