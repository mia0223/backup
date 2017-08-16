using TEK.SeatPlan.BusinessLogic.Mappers;
using TEK.SeatPlan.BusinessLogic.Contract;

namespace TEK.SeatPlan.WebApi.Controllers
{
    public class SeatController : BaseController
	{
		private readonly IEmployeeSeatComponent employeeSeatComponent;
	    private readonly IMoveComponent moveComponent;

        public SeatController(IEmployeeSeatComponent employeeSeatComponent,
            IMoveComponent moveComponent)
		{
			this.employeeSeatComponent = employeeSeatComponent;
		    this.moveComponent = moveComponent;
		}

		public Dto.Seat Get(int seatNumber)
		{
			return this.employeeSeatComponent.GetSeatByNumber(seatNumber).ToDto();
		}

		public void Post(Dto.SeatPair seatPair)
		{
		    this.moveComponent.Move(seatPair);
		}

		public void Put(Dto.Seat seat)
		{
			var seatEntity = seat.ToEntity(null);
			this.employeeSeatComponent.CreateSeat(seatEntity);
		}
	}
}