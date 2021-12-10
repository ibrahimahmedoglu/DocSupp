using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DocSupp.Data;
using Volo.Abp.DependencyInjection;

namespace DocSupp.EntityFrameworkCore
{
    public class EntityFrameworkCoreDocSuppDbSchemaMigrator
        : IDocSuppDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreDocSuppDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the DocSuppDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<DocSuppDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
