using System.Threading.Tasks;
using BatDemo.Configuration.Dto;

namespace BatDemo.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}








