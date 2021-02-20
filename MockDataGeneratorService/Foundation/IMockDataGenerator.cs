using MockMetadataReader.DTOs;
using MockDataGenerator.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MockDataGenerator.Foundation
{
    public interface IMockDataGenerator
    {
        Task<IEnumerable<MockObjectData>> GenerateMockDataByMetadataSchema(SchemaMetadata schema, MockDataGeneratorOptions[] options);
    }
}
