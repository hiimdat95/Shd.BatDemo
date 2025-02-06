using BatDemo.Utils.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BatDemo.Utils.Helpers
{
    public static class EnumHelper
    {
        public static string GetEnumDisplayName(Enum? enumValue)
        {
            if (enumValue != null)
            {
                var enumType = enumValue.GetType();
                var memberInfo = enumType.GetMember(enumValue.ToString()).FirstOrDefault();
                if (memberInfo != null)
                {
                    var displayAttribute = memberInfo.GetCustomAttribute<DisplayAttribute>();
                    if (displayAttribute != null)
                    {
                        return displayAttribute.Name ?? "No Name";
                    }
                }
                return enumValue.ToString();
            }
            else
            {
                return "";
            }    
        }
        public static List<KeyValuePair<string, T>> GetListEnumDisplayNamesAndValues<T>() where T : Enum
        {
            var enumType = typeof(T);
            var enumValues = Enum.GetValues(enumType).Cast<T>();

            var result = new List<KeyValuePair<string, T>>();

            foreach (var value in enumValues)
            {
                var memberInfo = enumType.GetMember(value.ToString())[0];
                var displayAttribute = memberInfo.GetCustomAttribute<DisplayAttribute>();

                var displayName = displayAttribute != null ? displayAttribute.Name : value.ToString();
                result.Add(new KeyValuePair<string, T>(displayName ?? "No Name", value));
            }

            return result;
        }
        public static IEnumerable<ComboboxEnumModel> GetListByEnum<T>() where T : Enum
        {
            var enumType = typeof(T);
            var enumValues = Enum.GetValues(enumType).Cast<T>();

            foreach (var value in enumValues)
            {
                var memberInfo = enumType.GetMember(value.ToString())[0];
                var displayAttribute = memberInfo.GetCustomAttribute<DisplayAttribute>();

                var displayName = displayAttribute != null ? displayAttribute.Name : value.ToString();
                yield return new ComboboxEnumModel
                {
                    Name = displayName ?? "No Name",
                    Value = Convert.ToInt32(value)
                };
            }
        }
    }
}






