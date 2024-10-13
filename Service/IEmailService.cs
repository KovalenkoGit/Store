using Store.Models;

namespace Store.Service
{
    public interface IEmailService
    {
        string GetEmailBody(string templateName);
        Task SendTestEmail(UserEmailOptions userEmailOptions);
        Task SendEmailForEmailConfirmation(UserEmailOptions userEmailOptions);
        Task SendEmailForForgotPassword(UserEmailOptions userEmailOptions);
    }
}