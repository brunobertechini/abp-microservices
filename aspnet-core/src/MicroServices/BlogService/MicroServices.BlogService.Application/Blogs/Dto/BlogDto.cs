using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroServices.BlogService.Blogs.Dto
{
    [AutoMapFrom(typeof(Blog))]
    public class BlogDto : FullAuditedEntityDto
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
