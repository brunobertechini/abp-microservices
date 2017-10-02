using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MicroServices.BlogService.Comments
{
    public class Comment : FullAuditedEntity, IMustHaveTenant
    {
        public const int MaxContentLength = 2000;

        public int TenantId { get; set; }

        [Required]
        [StringLength(MaxContentLength)]
        public virtual string Content { get; set; }
    }
}
