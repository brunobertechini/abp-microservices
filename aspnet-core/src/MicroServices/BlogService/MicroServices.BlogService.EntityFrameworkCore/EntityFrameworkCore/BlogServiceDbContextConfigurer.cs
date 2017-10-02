using Abp.Dependency;
using Abp.EntityFrameworkCore.Configuration;
using MicroServices.BlogService.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace MicroServices.BlogService.EntityFrameworkCore
{
    public static class BlogServiceDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<BlogServiceDbContext> builder, string connectionString)
        {
            IHostingEnvironment env = IocManager.Instance.Resolve<IHostingEnvironment>();
            var connString = env.GetAppConfiguration().GetConnectionString(BlogServiceConsts.ConnectionStringName);

            builder.UseSqlServer(connString);
        }

        public static void Configure(DbContextOptionsBuilder<BlogServiceDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }

        //public static void Configure(AbpDbContextConfiguration<BlogServiceDbContext> configuration)
        //{
        //    IHostingEnvironment env = IocManager.Instance.Resolve<IHostingEnvironment>();

        //    var connString = env.GetAppConfiguration().GetConnectionString(BlogServiceConsts.ConnectionStringName);

        //    if (configuration.ExistingConnection != null)
        //    {
        //        configuration.DbContextOptions.UseSqlServer(configuration.ExistingConnection);
        //    }
        //    else
        //    {
        //        configuration.DbContextOptions.UseSqlServer(connString);
        //    }
        //}
    }
}
