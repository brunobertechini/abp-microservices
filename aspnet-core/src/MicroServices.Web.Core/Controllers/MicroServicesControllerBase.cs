using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace MicroServices.Controllers
{
    public abstract class MicroServicesControllerBase: AbpController
    {
        protected MicroServicesControllerBase()
        {
            LocalizationSourceName = MicroServicesConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}