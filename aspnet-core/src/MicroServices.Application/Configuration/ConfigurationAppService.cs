using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using MicroServices.Configuration.Dto;

namespace MicroServices.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MicroServicesAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
