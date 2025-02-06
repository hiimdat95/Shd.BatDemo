using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BatDemo.SharedComponents
{
    public enum EducationType
    {
        [Display(Name = "Not Stated")]
        NoInfo = 0,
        [Display(Name = "High School")]
        School = 1,
        [Display(Name = "College")]
        College = 2,
        [Display(Name = "University Degree")]
        UniversityDegree = 3,
        [Display(Name = "PhD")]
        PhD = 4
    }

    public class EducationDegree
    {
        public EducationType Value { get; set; }
        public string DisplayName { get; set; }
    }

    public static class Extensions
    {
        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue)
                where TAttribute : Attribute => enumValue.GetType()
                                                         .GetMember(enumValue.ToString())
                                                         .First()
                                                         .GetCustomAttribute<TAttribute>();
    }
}







