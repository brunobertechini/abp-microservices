using System.Threading.Tasks;
using MicroServices.Configuration.Dto;

namespace MicroServices.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}