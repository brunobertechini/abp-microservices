using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MicroServices.BlogService.Blogs.Dto
{
    public class GetBlogInput
    {
        [Required]
        public int? Id { get; set; }
    }
}
