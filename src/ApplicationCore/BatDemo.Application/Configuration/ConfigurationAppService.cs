using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using BatDemo.Configuration.Dto;

namespace BatDemo.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : BatDemoAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}








