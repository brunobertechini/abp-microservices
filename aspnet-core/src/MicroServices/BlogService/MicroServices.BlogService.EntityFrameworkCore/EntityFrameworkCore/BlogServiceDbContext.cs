using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using MicroServices.BlogService.EntityFrameworkCore.Repositories;
using MicroServices.BlogService.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroServices.BlogService.EntityFrameworkCore
{
    [AutoRepositoryTypes(
        typeof(IBlogServiceRepository<>),
        typeof(IBlogServiceRepository<,>),
        typeof(BlogServiceRepositoryBase<>),
        typeof(BlogServiceRepositoryBase<,>)
    )]
    public class BlogServiceDbContext : AbpDbContext
    {
        public BlogServiceDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Entity Relationship for this MicroService
            ConfigureEntities(modelBuilder);

            // Add a default schema for this MicroService
            modelBuilder.HasDefaultSchema(BlogServiceConsts.DatabaseSchema);
        }

        private void ConfigureEntities(ModelBuilder modelBuilder)
        {
            // Add your custom configuration here
        }
    }
}
