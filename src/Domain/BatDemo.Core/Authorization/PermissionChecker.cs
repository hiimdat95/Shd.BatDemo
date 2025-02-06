using Abp.Authorization;
using BatDemo.Authorization.Roles;
using BatDemo.Authorization.Users;

namespace BatDemo.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}








