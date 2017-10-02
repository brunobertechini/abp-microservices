using System;
using System.Collections.Generic;
using System.Text;

namespace MicroServices.BlogService
{
    public static class BlogServiceAppConsts
    {
        /// <summary>
        /// Default page size for paged requests.
        /// </summary>
        public const int DefaultPageSize = 10;

        /// <summary>
        /// Maximum allowed page size for paged requests.
        /// </summary>
        public const int MaxPageSize = 1000;
    }
}
