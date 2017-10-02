using System.Threading.Tasks;
using Abp.Application.Services;
using MicroServices.Authorization.Accounts.Dto;

namespace MicroServices.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
