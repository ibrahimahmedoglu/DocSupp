using DocSupp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace DocSupp
{
    [DependsOn(
        typeof(DocSuppEntityFrameworkCoreTestModule)
        )]
    public class DocSuppDomainTestModule : AbpModule
    {

    }
}