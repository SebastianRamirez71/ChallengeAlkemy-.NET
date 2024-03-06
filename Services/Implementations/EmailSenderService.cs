using SendGrid.Helpers.Mail;
using SendGrid;
using challange_disney.Services.Interfaces;

namespace challange_disney.Services.Implementations
{
    public class EmailSenderService : IEmailSenderService
    {
        public async Task SendEmail(string email, string name)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("sebaprueba209@hotmail.com");
            var subject = "Te has registrado correctamente";
            var to = new EmailAddress($"{email}");
            var plainTextContent = "Gracias por registrarte.";
            var htmlContent = $"<strong>Bienvenido: {name}!</strong>" +
                "<br><strong> Challenge API .NET </strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
