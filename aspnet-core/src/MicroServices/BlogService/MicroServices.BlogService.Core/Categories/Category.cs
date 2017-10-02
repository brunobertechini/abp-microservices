using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MicroServices.BlogService.Categories
{
    public class Category : FullAuditedEntity
    {
        public const int MaxNameLength = 128;

        [Required]
        [StringLength(MaxNameLength)]
        public virtual string Name { get; set; }
    }
}
