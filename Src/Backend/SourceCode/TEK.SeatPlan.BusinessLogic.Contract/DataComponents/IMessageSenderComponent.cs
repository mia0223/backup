namespace TEK.SeatPlan.BusinessLogic.Contract
{
	public interface IMessageSenderComponent
	{
		void Send(Dto.SeatChangeMessage message);

		string GetMessageBody(Dto.SeatChangeMessage seatChangeMessage);
	}
}