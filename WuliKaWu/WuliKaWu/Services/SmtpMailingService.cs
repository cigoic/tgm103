using System.Net;
using System.Net.Mail;
using System.Text;

namespace WuliKaWu.Services
{
    public class SmtpMailingService : IMailService
    {
        private readonly SmtpClient _smtpClient;
        private readonly IConfiguration _configuration;

        public SmtpMailingService(SmtpClient smtpClient, IConfiguration configuration)
        {
            _smtpClient = smtpClient;
            _configuration = configuration;
        }

        public void SendMail(string from, string to, string subject, string body)
        {
            if (string.IsNullOrEmpty(from))
            {
                from = _configuration.GetValue<string>("SMTPConnection:MailFrom");
            }

            MailMessage mail = new MailMessage
            {
                From = new MailAddress(from),
                To = { to },
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
                SubjectEncoding = Encoding.UTF8
            };

            var SmtpAccessToken = _configuration.GetValue<string>("SMTPConnection:GmailSMTP");
            var SmtpAccessUser = _configuration.GetValue<string>("SMTPConnection:Username");
            var SmtpHostname = _configuration.GetValue<string>("SMTPConnection:Hostname");
            var SmtpPortNo = Convert.ToInt32(_configuration.GetValue<string>("SMTPConnection:PortNo"));
            _smtpClient.Host = SmtpHostname;
            _smtpClient.Port = SmtpPortNo;
            _smtpClient.EnableSsl = true;
            _smtpClient.Credentials = new NetworkCredential(SmtpAccessUser, SmtpAccessToken);

            _smtpClient.Send(mail);
        }
    }
}