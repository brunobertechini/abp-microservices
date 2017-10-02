using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Modules;
using Abp.Net.Mail;
using Abp.Reflection.Extensions;
using Abp.Zero;
using MicroServices.BlogService.Configuration;
using MicroServices.BlogService.Debugging;
using MicroServices.BlogService.Features;
using MicroServices.BlogService.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroServices.BlogService
{
    [DependsOn(
        typeof(AbpZeroCoreModule)
    )]
    public class BlogServiceCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            // Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            // Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            // Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            // Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            BlogServiceLocalizationConfigurer.Configure(Configuration.Localization);

            // Adding feature providers
            Configuration.Features.Providers.Add<BlogServiceFeatureProvider>();

            // Enable this line to create a multi-tenant application.
            // Configuration.MultiTenancy.IsEnabled = BlogServiceConsts.MultiTenancyEnabled;

            // Configure roles
            // AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            // Adding setting providers
            Configuration.Settings.Providers.Add<BlogServiceSettingsProvider>();

            // TODO AbpCustomization: Extract DebugHelper to shared project
            if (DebugHelper.IsDebug)
            {
                // Disabling email sending in debug mode
                Configuration.ReplaceService<IEmailSender, NullEmailSender>(DependencyLifeStyle.Transient);
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BlogServiceCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            // IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}
