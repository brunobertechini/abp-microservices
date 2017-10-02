using Abp.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroServices.BlogService.Configuration
{
    public class BlogServiceSettingsProvider : SettingProvider
    {
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new[]
            {
                new SettingDefinition(BlogServiceSettingNames.NewPostNotificationEnabled, "false", scopes: SettingScopes.Application | SettingScopes.Tenant | SettingScopes.User, isVisibleToClients: true),
            };
        }
    }
}
