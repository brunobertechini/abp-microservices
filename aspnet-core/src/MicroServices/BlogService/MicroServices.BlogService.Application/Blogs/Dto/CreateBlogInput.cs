using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MicroServices.BlogService.Blogs.Dto
{
    [AutoMapTo(typeof(Blog))]
    public class CreateBlogInput
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
