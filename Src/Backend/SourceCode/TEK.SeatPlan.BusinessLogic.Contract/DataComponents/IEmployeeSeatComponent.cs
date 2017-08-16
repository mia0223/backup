namespace TEK.SeatPlan.BusinessLogic.Contract
{
	public interface IEmployeeSeatComponent
	{
		Entity.Seat GetSeatByNumber(int seatNumber);

		//void Move(Dto.SeatPair seatPair);

		Entity.Seat CreateSeat(Entity.Seat seat);

		Entity.Seat GetSeatByEmployeeId(int employeeId);

		Dto.EmployeeSeatProject UpdateEmployeeSeatProject(Dto.EmployeeSeatProject employeeSeatProject);
	}
}