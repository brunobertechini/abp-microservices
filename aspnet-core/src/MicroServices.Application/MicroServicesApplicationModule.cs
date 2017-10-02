using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MicroServices.Authorization;

namespace MicroServices
{
    [DependsOn(
        typeof(MicroServicesCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MicroServicesApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<MicroServicesAuthorizationProvider>();
        }

        public override void Initialize()
        {
            Assembly thisAssembly = typeof(MicroServicesApplicationModule).GetAssembly();
            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(cfg =>
            {
                //Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg.AddProfiles(thisAssembly);
            });
        }
    }
}