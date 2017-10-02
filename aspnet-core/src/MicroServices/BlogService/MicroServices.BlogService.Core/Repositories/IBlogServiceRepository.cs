using Abp.Dependency;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroServices.BlogService.Repositories
{
    public interface IBlogServiceRepository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>, IRepository, ITransientDependency
        where TEntity : class, IEntity<TPrimaryKey>
    {

    }

    public interface IBlogServiceRepository<TEntity> : IBlogServiceRepository<TEntity, int>, ITransientDependency
        where TEntity : class, IEntity<int>
    {

    }
}
