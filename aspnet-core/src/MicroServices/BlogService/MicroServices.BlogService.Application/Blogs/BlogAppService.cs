using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using MicroServices.BlogService.Blogs.Dto;
using MicroServices.BlogService.Repositories;
using Abp.Authorization;
using MicroServices.BlogService.Authorization;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Abp.AutoMapper;

namespace MicroServices.BlogService.Blogs
{
    [AbpAuthorize(BlogServicePermissions.Blogs.Default)]
    public class BlogAppService : BlogAppServiceBase, IBlogAppService
    {
        private readonly IBlogServiceRepository<Blog> _blogRepository;

        public BlogAppService(
            IBlogServiceRepository<Blog> blogRepository
        )
        {
            _blogRepository = blogRepository;
        }

        public async Task<ListResultDto<BlogDto>> GetBlogs()
        {
            var blogs = await _blogRepository.GetAllIncluding(x => x.Posts)
                                             .OrderBy(x => x.Name)
                                             .ToListAsync();

            var dtos = blogs.MapTo<List<BlogDto>>();

            return new ListResultDto<BlogDto>(dtos);
        }

        public async Task<BlogDto> GetBlog(GetBlogInput input)
        {
            var blog = await _blogRepository.GetAllIncluding(x => x.Posts)
                                            .Where(x => x.Id == input.Id.Value)
                                            .SingleAsync();

            var dto = blog.MapTo<BlogDto>();

            return dto;
        }

        [AbpAuthorize(BlogServicePermissions.Blogs.Create)]
        public async Task<BlogDto> CreateBlog(CreateBlogInput input)
        {
            var blog = input.MapTo<Blog>();

            int id = await _blogRepository.InsertAndGetIdAsync(blog);
            blog.Id = id;

            var dto = blog.MapTo<BlogDto>();

            return dto;
        }

        [AbpAuthorize(BlogServicePermissions.Blogs.Edit)]
        public async Task<BlogDto> UpdateBlog(UpdateBlogInput input)
        {
            var blog = await _blogRepository.GetAsync(input.Id.Value);
            input.MapTo(blog);

            var dto = blog.MapTo<BlogDto>();

            return dto;
        }

        [AbpAuthorize(BlogServicePermissions.Blogs.Delete)]
        public async Task DeleteBlog(DeleteBlogInput input)
        {
            var blog = _blogRepository.Get(input.Id.Value);
            await _blogRepository.DeleteAsync(blog);
        }
    }
}
