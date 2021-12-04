using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Sda.Core
{
    [DependsOn(
     typeof(AbpDddDomainModule)
       )]
    public class SdaCoreDomainMoudle : AbpModule
    {
    }
}