using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MicroServices.MultiTenancy.Dto;

namespace MicroServices.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
