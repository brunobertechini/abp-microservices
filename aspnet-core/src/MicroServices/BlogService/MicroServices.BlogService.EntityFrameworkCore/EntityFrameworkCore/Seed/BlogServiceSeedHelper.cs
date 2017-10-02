using System;
using System.Transactions;
using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.EntityFrameworkCore.Uow;
using Abp.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using MicroServices.BlogService.EntityFrameworkCore;

namespace MicroServices.EntityFrameworkCore.Seed
{
    public static class BlogServiceSeedHelper
    {
        public static void SeedDatabase(IIocResolver iocResolver)
        {
            WithDbContext<BlogServiceDbContext>(iocResolver, SeedDatabase);
        }

        public static void SeedDatabase(BlogServiceDbContext context)
        {
            context.SuppressAutoSetTenantId = true;

            // Seed Database
        }

        private static void WithDbContext<TDbContext>(IIocResolver iocResolver, Action<TDbContext> contextAction)
            where TDbContext : DbContext
        {
            using (var uowManager = iocResolver.ResolveAsDisposable<IUnitOfWorkManager>())
            {
                using (var uow = uowManager.Object.Begin(TransactionScopeOption.Suppress))
                {
                    var context = uowManager.Object.Current.GetDbContext<TDbContext>(MultiTenancySides.Host);

                    contextAction(context);

                    uow.Complete();
                }
            }
        }
    }
}
