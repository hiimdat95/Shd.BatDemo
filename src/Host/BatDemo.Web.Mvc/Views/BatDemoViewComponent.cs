using Abp.AspNetCore.Mvc.ViewComponents;

namespace BatDemo.Web.Views
{
    public abstract class BatDemoViewComponent : AbpViewComponent
    {
        protected BatDemoViewComponent()
        {
            LocalizationSourceName = BatDemoConsts.LocalizationSourceName;
        }
    }
}








