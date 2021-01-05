
using System.Threading.Tasks;

using MockMetadataReader.DTOs;

namespace MockMetadataReader.Foundation
{
    
    public interface IDatabaseSchemaRead
    {
        Task<SchemaMetadata> ReadAllAsync();

        Task<SchemaMetadata> ReadRootObjectAndItsDependenciesAsync(params string[] rootObjects);

    }
}
