using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MicroServices.BlogService.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroServices.BlogService
{
    [DependsOn(
        typeof(BlogServiceApplicationModule),
        typeof(BlogServiceEntityFrameworkCoreModule),
        typeof(AbpAspNetCoreModule)
    )]
    public class BlogServiceWebCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            // Adding webapi generation
            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(BlogServiceApplicationModule).GetAssembly(),
                    moduleName: "BlogService"
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BlogServiceWebCoreModule).GetAssembly());
        }
    }
}
