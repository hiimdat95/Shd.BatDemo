using System.Collections.Generic;
using BatDemo.Roles.Dto;

namespace BatDemo.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}








