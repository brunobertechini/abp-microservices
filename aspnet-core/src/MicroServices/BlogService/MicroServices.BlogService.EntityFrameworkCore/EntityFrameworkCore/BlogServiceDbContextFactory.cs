using MicroServices.BlogService.Configuration;
using MicroServices.BlogService.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroServices.BlogService.EntityFrameworkCore
{
    public class BlogServiceDbContextFactory : IDesignTimeDbContextFactory<BlogServiceDbContext>
    {
        public BlogServiceDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<BlogServiceDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            BlogServiceDbContextConfigurer.Configure(builder, configuration.GetConnectionString(BlogServiceConsts.ConnectionStringName));

            return new BlogServiceDbContext(builder.Options);
        }
    }
}
