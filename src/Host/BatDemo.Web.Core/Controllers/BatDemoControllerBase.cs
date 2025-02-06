using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace BatDemo.Controllers
{
    public abstract class BatDemoControllerBase: AbpController
    {
        protected BatDemoControllerBase()
        {
            LocalizationSourceName = BatDemoConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}








