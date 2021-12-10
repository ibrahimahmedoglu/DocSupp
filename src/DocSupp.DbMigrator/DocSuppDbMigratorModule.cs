using DocSupp.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace DocSupp.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(DocSuppEntityFrameworkCoreModule),
        typeof(DocSuppApplicationContractsModule)
        )]
    public class DocSuppDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
