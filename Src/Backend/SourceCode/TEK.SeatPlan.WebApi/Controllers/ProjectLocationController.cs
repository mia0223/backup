using System.Linq;
using System.Web.Http;
using System.Collections.Generic;

using TEK.SeatPlan.BusinessLogic.Contract;
using TEK.SeatPlan.BusinessLogic.Mappers;

namespace TEK.SeatPlan.WebApi.Controllers
{
    public class ProjectLocationController : BaseController
    {
	    private readonly IDataService<Entity.Seat> dataService;

	    public ProjectLocationController(IDataService<Entity.Seat> dataService)
	    {
		    this.dataService = dataService;
	    }

	    public IEnumerable<Dto.Project> Get(int id)
	    {
		    var ret = dataService.Find(
				x => x.LocationId == id && x.Employee != null, null, x => x.Employee, x => x.Employee.Project)?
					.Select(x => x.Employee.Project).Distinct()
					.OrderBy(x => x.Name);

		    return ret.ToDto();
	    }
	}
}