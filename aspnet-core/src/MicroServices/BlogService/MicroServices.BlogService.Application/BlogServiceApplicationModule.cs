using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MicroServices.BlogService.Authorization;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroServices.BlogService
{
    [DependsOn(
        typeof(AbpAutoMapperModule),
        typeof(BlogServiceCoreModule)
    )]
    public class BlogServiceApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            // Adding authorization providers
            Configuration.Authorization.Providers.Add<BlogServiceAuthorizationProvider>();

            // Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(BlogServiceDtoMapper.CreateMappings);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BlogServiceApplicationModule).GetAssembly());
        }
    }
}
