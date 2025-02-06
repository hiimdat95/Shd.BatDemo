using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace BatDemo.Web.Views
{
    public abstract class BatDemoRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected BatDemoRazorPage()
        {
            LocalizationSourceName = BatDemoConsts.LocalizationSourceName;
        }
    }
}








