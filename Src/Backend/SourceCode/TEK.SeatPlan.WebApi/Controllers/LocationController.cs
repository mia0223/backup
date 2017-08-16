using System.Linq;
using System.Collections.Generic;

using TEK.SeatPlan.BusinessLogic.Mappers;
using TEK.SeatPlan.BusinessLogic.Contract;

namespace TEK.SeatPlan.WebApi.Controllers
{
    public class LocationController : BaseController
    {
	    private readonly IDataService<Entity.Location> locationDataService;

		public LocationController(IDataService<Entity.Location> locationDataService)
		{
			this.locationDataService = locationDataService;
		}

	    public IEnumerable<Dto.Location> Get()
	    {
		    return this.locationDataService
				.Find(x => x.Active && x.ParentId != null, x => x.OrderBy(y => y.Id))?
				.ToDto();
	    }
	}
}