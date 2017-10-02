using Abp.Dependency;
using Abp.Domain.Entities;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;
using MicroServices.BlogService.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroServices.BlogService.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Base class for custom repositories of the BlogService.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TPrimaryKey">Primary key type of the entity</typeparam>
    public class BlogServiceRepositoryBase<TEntity, TPrimaryKey> : EfCoreRepositoryBase<BlogServiceDbContext, TEntity, TPrimaryKey>, IBlogServiceRepository<TEntity, TPrimaryKey>, ITransientDependency
        where TEntity : class, IEntity<TPrimaryKey>
    {
        public BlogServiceRepositoryBase(IDbContextProvider<BlogServiceDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        // Add your common methods for all repositories
    }

    /// <summary>
    /// Base class for custom repositories of the application.
    /// This is a shortcut of <see cref="BlogServiceRepositoryBase{TEntity,TPrimaryKey}"/> for <see cref="int"/> primary key.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public class BlogServiceRepositoryBase<TEntity> : BlogServiceRepositoryBase<TEntity, int>, IBlogServiceRepository<TEntity>, ITransientDependency
        where TEntity : class, IEntity<int>
    {
        public BlogServiceRepositoryBase(IDbContextProvider<BlogServiceDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        // Do not add any method here, add to the class above (since this inherits it)!!!
    }
}
