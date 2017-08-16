using TEK.SeatPlan.BusinessLogic.Contract;

namespace TEK.SeatPlan.WebApi.Controllers
{
	public class EmailController : BaseController
	{
		private readonly IMessageSenderComponent emailSender;

		public EmailController(IMessageSenderComponent emailSender)
		{
			this.emailSender = emailSender;
		}

		public void Post(Dto.SeatChangeMessage emailDto)
		{
			emailSender.Send(emailDto);
		}

		public Dto.SeatChangeMessage Put(Dto.SeatChangeMessage emailDto)
		{
			if (emailDto != null && string.IsNullOrEmpty(emailDto.Body))
			{
				emailDto.Body = this.emailSender.GetMessageBody(emailDto);
			}

			return emailDto;
		}
	}
}