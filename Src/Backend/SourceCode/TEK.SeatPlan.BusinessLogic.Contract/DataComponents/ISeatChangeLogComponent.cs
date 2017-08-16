using System.Collections.Generic;

namespace TEK.SeatPlan.BusinessLogic.Contract
{
	public interface ISeatChangeLogComponent
	{
		Dto.SeatChangeLogPresenter[] GetSeatChangeLog();
	}
}