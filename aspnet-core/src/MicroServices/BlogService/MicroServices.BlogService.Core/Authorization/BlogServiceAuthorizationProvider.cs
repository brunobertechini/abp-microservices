using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.MultiTenancy;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroServices.BlogService.Authorization
{
    public class BlogServiceAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

        public BlogServiceAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public BlogServiceAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            var blogService = context.GetPermissionOrNull(BlogServicePermissions.BlogService)
                                ?? context.CreatePermission(BlogServicePermissions.BlogService, L("BlogService"), multiTenancySides: MultiTenancySides.Tenant);

            var blogs = blogService.CreateChildPermission(BlogServicePermissions.Blogs.Default, L("BlogService.Blogs"), multiTenancySides: MultiTenancySides.Tenant);

            blogs.CreateChildPermission(BlogServicePermissions.Blogs.Create, L("BlogService.Blogs.Permissions.Create"), multiTenancySides: MultiTenancySides.Tenant);
            blogs.CreateChildPermission(BlogServicePermissions.Blogs.Edit, L("BlogService.Blogs.Permissions.Edit"), multiTenancySides: MultiTenancySides.Tenant);
            blogs.CreateChildPermission(BlogServicePermissions.Blogs.Delete, L("BlogService.Blogs.Permissions.Delete"), multiTenancySides: MultiTenancySides.Tenant);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, BlogServiceConsts.LocalizationSourceName);
        }
    }
}
