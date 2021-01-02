using System.Threading.Tasks;

namespace DatabaseMetadataReaderService
{
    
    public interface IDatabaseSchemaRead
    {
        Task<DatabaseSchema> ReadAllAsync(string connectionString);

        Task<DatabaseSchema> ReadByRootDatabaseObjectAsync(string objectName, string connnectionString);

    }
}
