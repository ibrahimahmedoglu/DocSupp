using System.Threading.Tasks;

namespace DocSupp.Data
{
    public interface IDocSuppDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
