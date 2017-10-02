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
            // Debug for Package Manager Console
            Console.WriteLine(string.Format("BlogServiceDbContextConfigurer.Configure({0})", connectionString));

            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<BlogServiceDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
