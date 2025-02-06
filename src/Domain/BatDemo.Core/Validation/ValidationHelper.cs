using System;
using System.Text.RegularExpressions;
using Abp.Extensions;

namespace BatDemo.Validation
{
    public static class ValidationHelper
    {
        public const string EmailRegex = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

        public static bool IsEmail(string value)
        {
            if (value.IsNullOrEmpty())
            {
                return false;
            }

            var regex = new Regex(EmailRegex);
            return regex.IsMatch(value);
        }

        public static bool CheckIDIsEmptyOrNull(Object selectID)
        {
            if (selectID == null)
                return true;

            if (selectID.GetType().Equals(typeof(Guid)) &&
                (selectID.Equals(Guid.NewGuid())
                  || selectID.Equals(Guid.Empty)
                )
            )
            {
                return true;
            }

            if ((selectID.GetType().Equals(typeof(String)) || selectID.GetType().Equals(typeof(string)))
                && String.IsNullOrWhiteSpace(selectID.ToString())
            )
            {
                return true;
            }

            return false;

        }
    }
}








