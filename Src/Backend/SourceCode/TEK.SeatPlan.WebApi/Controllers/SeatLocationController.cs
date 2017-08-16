using System.Linq;
using System.Collections.Generic;

using TEK.SeatPlan.BusinessLogic.Contract;
using TEK.SeatPlan.BusinessLogic.Mappers;

namespace TEK.SeatPlan.WebApi.Controllers
{
    public class SeatLocationController : BaseController
	{
		private readonly IDataService<Entity.Seat> seatDataService;

		public SeatLocationController(IDataService<Entity.Seat> seatDataService)
		{
			this.seatDataService = seatDataService;
		}

		public IEnumerable<Dto.Seat> Get(int id)
		{
			IEnumerable<Dto.Seat> ret;

			if (id != 0)
			{
				ret = this.seatDataService.Find(
					x => x.Active && (x.LocationId == id || x.LocationId == 1),
					y => y.OrderBy(x => x.Number),
					x => x.Employee, x => x.Employee.Project, x => x.Employee.Status)?.ToDto();
			}
			else
			{
				ret = this.seatDataService.Find(
					x => x.Active,
					y => y.OrderBy(x => x.Number),
					x => x.Employee, x => x.Employee.Project, x => x.Employee.Status)?.ToDto();
			}

			return ret;
		}
	}
}