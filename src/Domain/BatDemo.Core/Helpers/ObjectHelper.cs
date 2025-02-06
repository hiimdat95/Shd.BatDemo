using System;
using System.Collections.Generic;
using System.Reflection;

namespace BatDemo.Domain.Core.Helpers
{
    public static class ObjectHelper
    {
        private static readonly IDictionary<string, Type> _dictTypeOfBaoCao = new Dictionary<string, Type>()
        {
        };

        public static List<PropertyModel> ListProperties(Type t)
        {
            List<PropertyModel> rs = new List<PropertyModel>();
            foreach (PropertyInfo p in t.GetProperties())
            {
                var propertyType = p.PropertyType;

                if (propertyType.IsGenericType &&
                        propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    propertyType = propertyType.GetGenericArguments()[0];
                }
                string propName = propertyType.Name;
                rs.Add(new PropertyModel { Name = p.Name, DataType = propName });
            }
            return rs;
        }

        public static Type GetTypeByTableName(string tableName)
        {
            return _dictTypeOfBaoCao.TryGetValue(tableName, out var type) ? type : null;
        }
    }
}