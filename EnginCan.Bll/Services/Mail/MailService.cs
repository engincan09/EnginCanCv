using Coravel.Queuing.Interfaces;
using EnginCan.Bll.EntityCore.Abstract.Systems;
using MailKit.Security;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EnginCan.Bll.Services.Mail
{
    public interface IMailService
    {
        Task SendNative(string body, string title, string mailAddress, string[] parameters = null);
        MimeMessage NewMailMessage(List<MailboxAddress> MailAddresses, string Subject, string Body);
        Task SendAsync(MimeMessage message);
    }

    public class MailService : IMailService
    {
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IMailConfigurationRepository _mailConfigurationRepository;

        public MailService(IConfiguration configuration, IHostingEnvironment hostingEnvironment, IMailConfigurationRepository mailConfigurationRepository)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
            _mailConfigurationRepository = mailConfigurationRepository;
        }


        /// <summary>
        /// Gönderilen değerlere göre yeni mail mesajı oluşturur.
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Name"></param>
        /// <param name="Subject"></param>
        /// <param name="Body"></param>
        /// <returns></returns>
        public MimeMessage NewMailMessage(List<MailboxAddress> MailAddresses, string Subject, string Body)
        {
            if (MailAddresses == null && MailAddresses.Count == 0)
                return null;

            var mailConfiguration = _mailConfigurationRepository.FindBy(m => m.DataStatus == Entity.Shared.DataStatus.Activated).FirstOrDefault();
            try
            {
                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = Body;
                // Mail Adress From Update Before Send
                MimeMessage mailMessage = new MimeMessage()
                {
                    Body = bodyBuilder.ToMessageBody(),
                    Subject = Subject,
                };

                mailMessage.From.Add(new MailboxAddress(mailConfiguration.DisplayName, mailConfiguration.Sender));

                foreach (var adress in MailAddresses)
                    mailMessage.To.Add(adress);

                return mailMessage;
            }
            catch { return null; }
        }


        /// <summary>
        /// Sistem değerlerinden mesajı çekerek gönderilen parametrelere göre formatlar ve
        /// sonucu ilgili kişiye mail gönderir.
        /// </summary>
        /// <param name="title">Mail konusudur.</param>
        /// <param name="mailAddress">Gönderilecek mail adresidir.</param>
        /// <param name="parameters">Mesajdaki değişken alanlardır.</param>
        /// <returns></returns>
        public async Task SendNative(string body, string title, string mailAddress, string[] parameters)
        {

            var newMailMessage = NewMailMessage(new List<MailboxAddress>() {
                                                     new MailboxAddress(mailAddress)
                                                    },
                                                    title,
                                                    parameters == null ? body : string.Format(body, parameters));

            await SendAsync(newMailMessage).ConfigureAwait(false);
        }

        /// <summary>
        /// Mail mesajlarını hedeflerine gönderilmesini sağlar.
        /// </summary>
        /// <param name="message">Gönderilecek mesajlardır.</param>
        /// <returns></returns>
        public async Task SendAsync(MimeMessage message)
        {
            var mailConfiguration = _mailConfigurationRepository.FindBy(m => m.DataStatus == Entity.Shared.DataStatus.Activated).FirstOrDefault();
            if (message != null || message.To.Count != 0)
            {

                using (MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient())
                {
                    try
                    {
                        client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                        client.Connect(
                         mailConfiguration.Host,
                         Convert.ToInt32(mailConfiguration.Port),
                          SecureSocketOptions.StartTls);

                        client.Authenticate(mailConfiguration.UserName, mailConfiguration.Password);
                        client.Send(message);
                        client.Disconnect(true);
                        client.Dispose();
                    }
                    catch (Exception ex)
                    {
                        using (StreamWriter file = new StreamWriter("uris.txt", append: true))
                        {
                            file.WriteLine("\"MAİL GÖNDERME HATASI\" = '" + ex.Message);
                        }
                        throw ex;
                    }
                }

            }
        }

    }
}
