
using System.Threading.Tasks;

using DatabaseMetadataReader.DTOs;

namespace DatabaseMetadataReader.Foundation
{
    
    public interface IDatabaseSchemaRead
    {
        Task<SchemaMetadata> ReadAllAsync();

        Task<SchemaMetadata> ReadRootObjectAndItsDependenciesAsync(params string[] rootObjects);

    }
}
