using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace DocSupp.Data
{
    /* This is used if database provider does't define
     * IDocSuppDbSchemaMigrator implementation.
     */
    public class NullDocSuppDbSchemaMigrator : IDocSuppDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}