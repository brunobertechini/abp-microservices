using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MicroServices.Roles.Dto;
using MicroServices.Users.Dto;

namespace MicroServices.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();
    }
}