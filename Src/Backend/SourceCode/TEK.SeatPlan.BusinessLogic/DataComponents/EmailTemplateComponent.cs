using System.IO;
using System.Reflection;
using TEK.SeatPlan.BusinessLogic.Contract;
using TEK.SeatPlan.Dto;

namespace TEK.SeatPlan.BusinessLogic.DataComponents
{
    public class EmailTemplateComponent : DataComponentBase, IEmailTemplateComponent
    {
        public EmailTemplate GetEditableSections()
        {
            var editableContent = new EmailTemplate()
            {
                ContentSection1 = System.Net.WebUtility.HtmlEncode(GetMessageTemplate("EmailMailTemplate_Section1")),
                ContentSection2 = System.Net.WebUtility.HtmlEncode(GetMessageTemplate("EmailMailTemplate_Section2"))
            };
            return editableContent;
        }

        public string GetFullEmailTemplate()
        {
            var mailTemplate = GetMessageTemplate("GroupMailTemplate_full");
            return mailTemplate;
        }

        public string GetEditableEmailTemplate()
        {
            var mailTemplate = GetMessageTemplate("GroupMailTemplate_editable");
            return mailTemplate;
        }

        public string GetChangeLogTableTemplate()
        {
            var rowTemplate = GetMessageTemplate("GroupMailRowTemplate");
            return rowTemplate;
        }

        private static string GetMessageTemplate(string resourceName)
        {
            var template = string.Empty;
            var assembly = Assembly.GetExecutingAssembly();

            resourceName = $"{assembly.GetName().Name}.Resources.{resourceName}.html";

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null) return template;
                using (var reader = new StreamReader(stream))
                {
                    template = reader.ReadToEnd();
                }
            }

            return template;
        }
    }
}
