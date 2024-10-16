using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;

namespace WebApp;

public class EmailSender : IEmailSender
{
    EmailSettings emailSettings;
    public EmailSender(IOptions<EmailSender> options)
    {

    }
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        throw new NotImplementedException();
    }
}