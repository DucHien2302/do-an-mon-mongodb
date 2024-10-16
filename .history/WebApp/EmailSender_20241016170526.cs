using Microsoft.AspNetCore.Identity.UI.Services;

namespace WebApp;

public class EmailSender : IEmailSender
{
    EmailSettings emailSettings;
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        throw new NotImplementedException();
    }
}