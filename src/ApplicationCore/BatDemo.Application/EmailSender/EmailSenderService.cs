using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Razor.Templating.Core;

namespace BatDemo.EmailSender
{
    /// <summary>
    /// 
    /// </summary>
    public class EmailSenderService : IEmailSender
    {
        private readonly IConfiguration Configuration;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public EmailSenderService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var SmtpConfigs = new SmtpSettings();
            Configuration.GetSection("SmtpSettings").Bind(SmtpConfigs);

            var mailMessage = new MailMessage
            {
                From = new MailAddress(SmtpConfigs.SenderEmail, SmtpConfigs.SenderName),
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };

            mailMessage.To.Add(email);

            using (var client = new SmtpClient(SmtpConfigs.Server, SmtpConfigs.Port))
            {
                client.Credentials = new NetworkCredential(SmtpConfigs.Username, SmtpConfigs.Password);
                client.EnableSsl = SmtpConfigs.EnableSsl;

                await client.SendMailAsync(mailMessage);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="viewName"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<string> RenderTemplate<TModel>(string viewName, TModel model)
        {
            string emailBody = await RazorTemplateEngine.RenderAsync(viewName, model);
            return emailBody;
        }
    }
}





