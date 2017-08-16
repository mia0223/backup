using System;

using TEK.SeatPlan.BusinessLogic.Contract;
using TEK.SeatPlan.BusinessLogic.Mappers;

namespace TEK.SeatPlan.WebApi.Controllers
{
	public class SeatChangeLogController : BaseController
	{
		private readonly ISeatChangeLogComponent seatChangeLogComponent;

		public SeatChangeLogController(ISeatChangeLogComponent seatChangeLogComponent)
		{
			this.seatChangeLogComponent = seatChangeLogComponent;
		}

		public Dto.SeatChangeLogPresenter[] Get()
		{
			return this.seatChangeLogComponent.GetSeatChangeLog();
		}
	}
}