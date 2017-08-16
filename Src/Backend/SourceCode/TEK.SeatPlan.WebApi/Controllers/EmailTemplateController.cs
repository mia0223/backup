using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TEK.SeatPlan.BusinessLogic.Contract;

namespace TEK.SeatPlan.WebApi.Controllers
{
    public class EmailTemplateController : BaseController
    {
        private readonly IEmailTemplateComponent emailTemplateComponent;

        public EmailTemplateController(IEmailTemplateComponent emailTemplateComponent)
        {
            this.emailTemplateComponent = emailTemplateComponent;
        }

        public Dto.EmailTemplate Get()
        {
            var emailTemplate = emailTemplateComponent.GetEditableSections();
            return emailTemplate;
        }
    }
}
