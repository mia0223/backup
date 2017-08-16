namespace TEK.SeatPlan.BusinessLogic.Contract
{
    public interface IEmailTemplateComponent
    {
        Dto.EmailTemplate GetEditableSections();
        string GetFullEmailTemplate();
        string GetEditableEmailTemplate();
        string GetChangeLogTableTemplate();
    }
}