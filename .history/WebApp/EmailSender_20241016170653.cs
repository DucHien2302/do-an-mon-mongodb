using System.Net.Mail;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;

namespace WebApp;

public class EmailSender : IEmailSender
{
    EmailSettings emailSettings;
    public EmailSender(IOptions<EmailSender> options)
    {
        emailSettings = options.Value.emailSettings;
    }
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        SmtpClient client = new SmtpClient
        {
            Host = emailSettings.Host,
        };
    }
}