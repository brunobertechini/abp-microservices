using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using MicroServices.BlogService.Blogs;
using MicroServices.BlogService.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MicroServices.BlogService.Posts
{
    public class Post : FullAuditedEntity, IMustHaveTenant
    {
        public const int MaxTitleLength = 128;

        private Post()
        { } // Required for EF

        public Post(Blog blog)
        {
            Status = PostStatus.Draft;
        }

        public int TenantId { get; set; }

        public int BlogId { get; set; }

        public int CategoryId { get; set; }

        [Required]
        [StringLength(MaxTitleLength)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string Tags { get; set; }

        public PostStatus Status { get; set; }

        public virtual Blog Blog { get; set; }

        public virtual Category Category { get; set; }
    }
}
