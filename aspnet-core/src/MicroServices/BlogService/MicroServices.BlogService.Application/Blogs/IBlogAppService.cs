using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MicroServices.BlogService.Blogs.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroServices.BlogService.Blogs
{
    public interface IBlogAppService : IApplicationService
    {
        Task<ListResultDto<BlogDto>> GetBlogs();

        Task<BlogDto> GetBlog(GetBlogInput input);

        Task<BlogDto> CreateBlog(CreateBlogInput input);

        Task<BlogDto> UpdateBlog(UpdateBlogInput input);

        Task DeleteBlog(DeleteBlogInput input);
    }
}
