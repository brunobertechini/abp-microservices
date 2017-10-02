using System.Threading.Tasks;
using Abp.Application.Services;
using MicroServices.Sessions.Dto;

namespace MicroServices.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
