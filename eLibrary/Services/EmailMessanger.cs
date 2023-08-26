using System.Net.Mail;
using System.Net;
using eLibrary.Services.IServices;

namespace eLibrary.Services;

public class EmailMessanger : IMessanger
{
    private readonly IConfiguration _config;
    public EmailMessanger(IConfiguration config)
    {
        _config = config;
    }

    public string Send(string Subject, string UserEmail ,string Body, string AttachmentPath = "")
    {
        try
        {
            string GmailAccount = _config["SenderEmail"]!;
            string GmailPassword = _config["Password"]!;
            string ToEmail = UserEmail;

            MailMessage myMail = new(GmailAccount, ToEmail)
            {
                Subject = Subject,
                Body = Body,
                IsBodyHtml = true
            };

            if (!string.IsNullOrEmpty(AttachmentPath))
            {
                Attachment attachment = new Attachment(AttachmentPath);
                myMail.Attachments.Add(attachment);
                myMail.Priority = MailPriority.High;
            }
            SmtpClient smtpClient = new("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(GmailAccount, GmailPassword)
            };
            smtpClient.Send(myMail);

            return "";
        }
        catch (Exception e)
        {
            return "error: " + e.Message;
        }
    }
}
