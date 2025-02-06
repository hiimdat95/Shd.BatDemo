using Abp.Localization;
using System;

namespace BatDemo.Localization
{
    public static class LC
    {
        public static String L(String input)
        {
            var _lo = LocalizationHelper.GetSource(BatDemoConsts.LocalizationSourceName);
            return _lo.GetString(input);
        }

    }

}







