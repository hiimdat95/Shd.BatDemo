using System.ComponentModel.DataAnnotations;

namespace BatDemo.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}







