using System.Threading.Tasks;

namespace BatDemo.EmailSender
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEmailSender
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        Task SendEmailAsync(string email, string subject, string message);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="templateName"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<string> RenderTemplate<TModel>(string templateName, TModel model);
    }
}






