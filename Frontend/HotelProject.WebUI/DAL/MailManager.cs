using MailKit.Net.Smtp;
using MimeKit;

namespace HotelProject.WebUI.Dtos.DAL
{
    public static class MailManager
    {
        public static void SendMail(string subject, string mail, string contentbody)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Hotellier Admin", "aspnetcoreprojeler@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = contentbody;

            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = subject;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("aspnetcoreprojeler@gmail.com", "jpag jffd lkcu mhas");

            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);
        }
    }
}
