using System.Text;
using System.Linq;
using System.Net.Mail;
using System.Configuration;
using System.Collections.Generic;
using TEK.SeatPlan.Common;
using TEK.SeatPlan.BusinessLogic.Contract;
using TEK.SeatPlan.Dto;
using TEK.SeatPlan.ResourceAccess.Contract;

namespace TEK.SeatPlan.BusinessLogic
{
    public class EmailComponent : DataComponentBase, IMessageSenderComponent
    {
        private readonly IRepository<Entity.SeatChangeLog> seatChangeLogRepository;
        private readonly IEmailTemplateComponent emailTemplateComponent;

        public EmailComponent(IRepository<Entity.SeatChangeLog> seatChangeLogRepository, IEmailTemplateComponent emailTemplateComponent) : base()
        {
            this.seatChangeLogRepository = seatChangeLogRepository;
            this.emailTemplateComponent = emailTemplateComponent;
        }

        public void Send(Dto.SeatChangeMessage seatChangeMessage)
        {
            Requires.ArgumentNotNull(seatChangeMessage, "seatChangeMessage");

            var smtpHost = ConfigurationManager.AppSettings["smtpHost"];

            using (var smtpClient = new SmtpClient { UseDefaultCredentials = true, Host = smtpHost })
            {
                using (var message = new MailMessage { IsBodyHtml = true })
                {
                    message.From = new MailAddress(ConfigurationManager.AppSettings["smtpSender"]);

                    if (!string.IsNullOrWhiteSpace(seatChangeMessage.CC))
                    {
                        if (seatChangeMessage.CC.IndexOf(';') > 0)
                        {
                            foreach (var cc in seatChangeMessage.CC.Split(';')) message.CC.Add(new MailAddress(cc));
                        }
                        else
                        {
                            message.CC.Add(new MailAddress(seatChangeMessage.CC));
                        }
                    }

                    foreach (var cc in ConfigurationManager.AppSettings["smtpCC"].Split(';'))
                    {
                        if (!message.CC.Contains(new MailAddress(cc)))
                        {
                            message.CC.Add(new MailAddress(cc));
                        }
                    }

                    if (seatChangeMessage.To.IndexOf(';') > 0)
                    {
                        foreach (var to in seatChangeMessage.To.Split(';')) message.To.Add(new MailAddress(to));
                    }
                    else
                    {
                        message.To.Add(seatChangeMessage.To);
                    }

                    if (string.IsNullOrEmpty(seatChangeMessage.Subject))
                    {
                        message.Subject = "Please Read: Change of Seating Assignment";
                    }
                    else
                    {
                        message.Subject = seatChangeMessage.Subject;
                    }

                    message.Body = this.ComposeMessageBody(seatChangeMessage);

                    smtpClient.Send(message);
                }
            }

            this.UpdateMailSentFlag(seatChangeMessage.SeatChangeLog);
            this.seatChangeLogRepository.SaveChanges();

            this.Logger.InfoFormat("Mail sent to {0} and {1}", seatChangeMessage.To, seatChangeMessage.CC);
        }

        public string GetMessageBody(Dto.SeatChangeMessage seatChangeMessage)
        {
            Requires.ArgumentNotNull(seatChangeMessage, "seatChangeMessage");

            return this.ComposeMessageBody(seatChangeMessage);
        }

        private string ComposeMessageBody(Dto.SeatChangeMessage seatChangeMessage)
        {
            var emailTemplate = default(string);
            var employeeListBuilder = GetHtmlForRowTemplate(seatChangeMessage);

            if (!string.IsNullOrWhiteSpace(seatChangeMessage.ContentSection1)
                && !string.IsNullOrWhiteSpace(seatChangeMessage.ContentSection2))
            {
                emailTemplate = this.emailTemplateComponent.GetEditableEmailTemplate();
                emailTemplate = emailTemplate.Replace("[ContentSection1]", System.Net.WebUtility.HtmlDecode(seatChangeMessage.ContentSection1));
                emailTemplate = emailTemplate.Replace("[ContentSection2]", System.Net.WebUtility.HtmlDecode(seatChangeMessage.ContentSection2));
            }
            else
            {
                //TO DO: to be removed once email content editing has been correctly tested and validated
                // This is to keep backward compatibility
                emailTemplate = this.emailTemplateComponent.GetFullEmailTemplate();
                emailTemplate = emailTemplate.Replace("[MoveDate]", seatChangeMessage.MoveDate ?? "&nbsp;&nbsp;&nbsp;");
            }
            emailTemplate = emailTemplate.Replace("[ModedEmployeeRow]", employeeListBuilder.ToString());
            this.Logger.Debug("ComposeMessageBody message prepared");

            return emailTemplate;
        }

        private StringBuilder GetHtmlForRowTemplate(SeatChangeMessage seatChangeMessage)
        {
            var rowTemplate = this.emailTemplateComponent.GetChangeLogTableTemplate();

            var employeeListBuilder = new StringBuilder();

            foreach (var movedEmployee in seatChangeMessage.SeatChangeLog.Where(x => x.Selected))
            {
                var nextTRline = rowTemplate
                    .Replace("[EmployeeName]", $"{movedEmployee.Employee.LastName},&nbsp{movedEmployee.Employee.FirstName}")
                    .Replace("[NewSeat]", GetFormattedSeatNumber(movedEmployee.TargetSeat.Number))
                    .Replace("[PreviousSeat]", GetFormattedSeatNumber(movedEmployee.SourceSeat.Number))
                    .Replace("[ProjectType]", movedEmployee.Employee.Project.Internal ? "Internal" : string.Empty)
                    .Replace("[ProjectName]", movedEmployee.Employee.Project.Name);

                employeeListBuilder.AppendLine(nextTRline);
            }
            return employeeListBuilder;
        }

        private void UpdateMailSentFlag(IEnumerable<Dto.SeatChangeLog> seatChangeLog)
        {
            foreach (var seatChangeLogDto in seatChangeLog)
            {
                var seatChangeLogEntity = this.seatChangeLogRepository.Get(x => x.Id == seatChangeLogDto.Id);

                seatChangeLogEntity.MailSent = true;
                this.seatChangeLogRepository.Update(seatChangeLogEntity);
            }
        }

        private static string GetFormattedSeatNumber(int seatNumber)
        {
            return seatNumber < 9000 ? seatNumber.ToString() : "Transit";
        }
    }
}