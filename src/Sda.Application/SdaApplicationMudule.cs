using Sda.Core;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Sda.Application
{
    [DependsOn(
    typeof(SdaCoreDomainMoudle)
      )]
    public class SdaApplicationMudule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(opt =>
            {
                opt.AddProfile<SdaAplicationProfile>();
            });
        }
    }
}