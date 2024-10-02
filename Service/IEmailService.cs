using Store.Models;

namespace Store.Service
{
    public interface IEmailService
    {
        string GetEmailBody(string templateName);
        Task SendTestEmail(UserEmailOptions userEmailOptions);
        Task SendEmailFromEmailConfirmation(UserEmailOptions userEmailOptions);
    }
}