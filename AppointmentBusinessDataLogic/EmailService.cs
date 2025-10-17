using MailKit.Net.Smtp;
using MimeKit;

namespace AppointmentBusinessLogic
{
    class EmailService
    {
        public void SendEmailToAdmin(string name, string email, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Client", "client@example.com"));
            message.To.Add(new MailboxAddress("Admin", "aestheticclinic@admin.com"));
            message.ReplyTo.Add(new MailboxAddress(name, email));
            message.Subject = subject;
            message.Body = new TextPart("plain")
            {
                Text = body
            };

            using (var client = new SmtpClient())
            {
                var smtpHostn = "sandbox.smtp.mailtrap.io";
                var smtpPort = 2525;
                var tls = MailKit.Security.SecureSocketOptions.StartTls;
                client.Connect(smtpHostn, smtpPort, tls);

                var userName = "c4c4b4470fbc07";
                var password = "11abc0ba76591d";

                client.Authenticate(userName, password);

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
