using System.Collections.Generic;

namespace BatDemo.Web.Models.Users
{
    public class InputUpdateRoleModel
    {
        public string UserNameAd { get; set; }
        public string FullName { get; set; }
        public string StatusUser { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string RoleCode { get; set; }
        public string CompanyCode { get; set; }
        public List<Department> Departments { get; set; }
    }

    public class Department
    { 
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}






