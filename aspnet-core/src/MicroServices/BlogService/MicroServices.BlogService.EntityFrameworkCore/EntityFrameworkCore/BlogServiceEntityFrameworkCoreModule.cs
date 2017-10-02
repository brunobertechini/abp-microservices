using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using MicroServices.BlogService.Configuration;
using MicroServices.EntityFrameworkCore.Seed;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroServices.BlogService.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpZeroCoreEntityFrameworkCoreModule),
        typeof(BlogServiceCoreModule)
    )]
    public class BlogServiceEntityFrameworkCoreModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<BlogServiceDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        BlogServiceDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        IHostingEnvironment env = IocManager.Resolve<IHostingEnvironment>();
                        var connString = env.GetAppConfiguration().GetConnectionString(BlogServiceConsts.ConnectionStringName);

                        BlogServiceDbContextConfigurer.Configure(options.DbContextOptions, connString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BlogServiceEntityFrameworkCoreModule).GetAssembly());

            //// Initialize Database
            //var env = IocManager.Resolve<IHostingEnvironment>();
            //var dbContext = new ProjectManagementDbContextFactory().Create(new DbContextFactoryOptions()
            //{
            //    EnvironmentName = env.EnvironmentName
            //});
            //dbContext.Database.Migrate();
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                BlogServiceSeedHelper.SeedDatabase(IocManager);
            }
        }
    }
}
