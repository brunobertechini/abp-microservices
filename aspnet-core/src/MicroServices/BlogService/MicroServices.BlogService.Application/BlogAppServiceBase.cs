using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Microsoft.AspNetCore.Identity;

namespace MicroServices.BlogService
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class BlogAppServiceBase : ApplicationService
    {
        protected BlogAppServiceBase()
        {
            LocalizationSourceName = BlogServiceConsts.LocalizationSourceName;
        }
    }
}