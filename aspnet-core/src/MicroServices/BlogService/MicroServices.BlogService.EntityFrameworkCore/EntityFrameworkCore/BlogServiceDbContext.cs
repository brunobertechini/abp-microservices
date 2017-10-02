using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using MicroServices.BlogService.Blogs;
using MicroServices.BlogService.Categories;
using MicroServices.BlogService.Comments;
using MicroServices.BlogService.EntityFrameworkCore.Repositories;
using MicroServices.BlogService.Posts;
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

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }

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
