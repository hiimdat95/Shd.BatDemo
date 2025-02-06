using System.ComponentModel.DataAnnotations;
namespace BatDemo.Constants
{
    public enum SystemParamStatus
    {
        [Display(Name = "Không hoạt động")]
        Disable = 0,

        [Display(Name = "Đang hoạt động")]
        Active = 1
    }
}






