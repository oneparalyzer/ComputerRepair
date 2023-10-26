using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Options;
using ComputerRepair.Infrastructure.Email.Options;
using ComputerRepair.Application.Common.Interfaces.Email;

namespace ComputerRepair.Infrastructure.Email;

public class EmailSender : IEmailSender
{
    private readonly EmailOptions _emailOptions;

    public EmailSender(IOptions<EmailOptions> options)
    {
        _emailOptions = options.Value;
    }

    public void Send(string toAddress, string subject, string body)
    {
        using (SmtpClient client = new SmtpClient(_emailOptions.SmtpServer, _emailOptions.SmtpPort))
        {
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(_emailOptions.SmtpUsername, _emailOptions.SmtpPassword);
            client.EnableSsl = true;

            using (MailMessage message = new MailMessage(_emailOptions.FromAddress, toAddress, subject, body))
            {
                client.Send(message);
            }
        }
    }
}
