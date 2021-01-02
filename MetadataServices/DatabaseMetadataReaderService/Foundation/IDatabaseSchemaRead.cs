
using System.Threading.Tasks;

using DatabaseMetadataReaderService.DTOs;

namespace DatabaseMetadataReaderService.Foundation
{
    
    public interface IDatabaseSchemaRead
    {
        Task<DatabaseSchema> ReadAllAsync();

        Task<DatabaseSchema> ReadRootObjectAndItsDependenciesAsync(params string[] rootObjects);

    }
}
