
using System.Threading.Tasks;

using DatabaseMetadataReaderService.DTOs;

namespace DatabaseMetadataReaderService.Foundation
{
    
    public interface IDatabaseSchemaRead
    {
        Task<SchemaMetadata> ReadAllAsync();

        Task<SchemaMetadata> ReadRootObjectAndItsDependenciesAsync(params string[] rootObjects);

    }
}
