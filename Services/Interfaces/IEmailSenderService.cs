namespace challange_disney.Services.Interfaces
{
    public interface IEmailSenderService
    {
        Task SendEmail(string email, string name);
    }
}
