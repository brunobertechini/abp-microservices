using System;
using System.Collections.Generic;
using System.Text;

namespace MicroServices.BlogService.Authorization
{
    public static class BlogServicePermissions
    {
        public const string BlogService = "BlogService";

        public static class Blogs
        {
            public const string Default = "BlogService.Blogs";

            public const string Create = "BlogService.Blogs.Create";
            public const string Edit = "BlogService.Blogs.Update";
            public const string Delete = "BlogService.Blogs.Delete";
        }
    }
}
