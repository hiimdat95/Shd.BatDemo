using System.Collections.Generic;
using BatDemo.Roles.Dto;

namespace BatDemo.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}








