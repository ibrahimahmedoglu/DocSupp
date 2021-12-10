using Volo.Abp.Modularity;

namespace DocSupp
{
    [DependsOn(
        typeof(DocSuppApplicationModule),
        typeof(DocSuppDomainTestModule)
        )]
    public class DocSuppApplicationTestModule : AbpModule
    {

    }
}