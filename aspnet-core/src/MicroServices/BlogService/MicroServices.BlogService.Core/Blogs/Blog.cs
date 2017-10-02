using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using MicroServices.BlogService.Posts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MicroServices.BlogService.Blogs
{
    public class Blog : FullAuditedEntity, IMustHaveTenant
    {
        public int TenantId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual List<Post> Posts { get; set; }
    }
}
