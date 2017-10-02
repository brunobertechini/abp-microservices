using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroServices.BlogService.Localization
{
    public static class BlogServiceLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(BlogServiceConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(BlogServiceLocalizationConfigurer).GetAssembly(),
                        "BlogService.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
