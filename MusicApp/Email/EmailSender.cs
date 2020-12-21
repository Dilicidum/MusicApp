using API.Interfaces;
using BLL.Models.Configurations;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace API.Email
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration emailConfiguration;
        
        public EmailSender(EmailConfiguration emailConfiguration)
        {
            this.emailConfiguration = emailConfiguration;
            
        }

        public void SendEmail(Message message)
        {
            var mail = CreateMimeMessage(message);
            SendEmail(mail);
        }

        public async Task SendEmailAsync(Message message)
        {
            var mail = CreateMimeMessage(message);
            await SendEmailAsync(mail);
        }

        public MimeMessage CreateMimeMessage(Message message)
        {
            MimeMessage res = new MimeMessage();
            res.From.Add(new MailboxAddress(emailConfiguration.From));
            res.To.AddRange(message.To);
            res.Subject = message.Subject;
            res.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };
            return res;
        }

        public void SendEmail(MimeMessage mail)
        {
            using (var client = new SmtpClient() )
            {
                try{
                    client.Connect(emailConfiguration.SmtpServer, emailConfiguration.Port, true);
                    client.Authenticate(emailConfiguration.UserName, emailConfiguration.Password);
                    client.Send(mail);
                }
                catch (Exception ex)
                {
                    
                }
                finally{
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        public async Task SendEmailAsync(MimeMessage mail)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(emailConfiguration.SmtpServer, emailConfiguration.Port, true);
                    await client.AuthenticateAsync(emailConfiguration.UserName, emailConfiguration.Password);
                    await client.SendAsync(mail);
                }
                catch(Exception ex)
                {

                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }
    }
}
