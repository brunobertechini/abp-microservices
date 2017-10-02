using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MicroServices.MultiTenancy;

namespace MicroServices.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}