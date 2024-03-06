using SendGrid.Helpers.Mail;
using SendGrid;
using challange_disney.Services.Interfaces;

namespace challange_disney.Services.Implementations
{
    public class EmailSenderService : IEmailSenderService
    {
        public async Task SendEmail(string email, string name)
        {
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
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
