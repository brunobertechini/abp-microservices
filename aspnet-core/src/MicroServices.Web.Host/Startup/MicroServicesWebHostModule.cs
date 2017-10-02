using System.Reflection;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MicroServices.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace MicroServices.Web.Host.Startup
{
    [DependsOn(
       typeof(MicroServicesWebCoreModule))]
    public class MicroServicesWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MicroServicesWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MicroServicesWebHostModule).GetAssembly());
        }
    }
}
