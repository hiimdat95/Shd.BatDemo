using System.ComponentModel.DataAnnotations;
using Abp.Auditing;

namespace BatDemo.Web.Models.Account
{
    public class LoginViewModel
    {
        [Required]
        public string UsernameOrEmailAddress { get; set; }

        [Required]
        [DisableAuditing]
        public string Password { get; set; }

        public string Otp { get; set; }

        public bool RememberMe { get; set; }
    }
}








