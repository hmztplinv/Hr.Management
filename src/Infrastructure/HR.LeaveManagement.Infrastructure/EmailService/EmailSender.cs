using HR.LeaveManagement.Application.Contracts.Email;
using HR.LeaveManagement.Application.Models.Email;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace HR.LeaveManagement.Infrastructure.EmailService;

public class EmailSender: IEmailSender
{
    public EmailSettings _emailSettings { get; }
    public EmailSender(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;
    }
    public async Task<bool> SendEmailAsync(EmailMessage message)
    {
        var client = new SendGridClient(_emailSettings.ApiKey);
        var to = new EmailAddress(message.To);
        var from = new EmailAddress
        {
            Email = _emailSettings.FromAddress,
            Name = _emailSettings.FromName
        };
        
        var msg = MailHelper.CreateSingleEmail(from, to, message.Subject, message.Body, message.Body);
        var response =await client.SendEmailAsync(msg);
        // return response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.Accepted;
        return response.IsSuccessStatusCode;
    }
}