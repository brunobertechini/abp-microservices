using Abp.Authorization;
using MicroServices.Authorization.Roles;
using MicroServices.Authorization.Users;

namespace MicroServices.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
