using Abp.Application.Features;
using Abp.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroServices.BlogService.Features
{
    public class BlogServiceFeatureProvider : FeatureProvider
    {
        public override void SetFeatures(IFeatureDefinitionContext context)
        {
            var businessIntelligence = context.Create(
                BlogServiceFeatures.ProjectManagement,
                defaultValue: "false",
                displayName: L("BlogService.Features.BlogManagement"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, BlogServiceConsts.LocalizationSourceName);
        }
    }
}
