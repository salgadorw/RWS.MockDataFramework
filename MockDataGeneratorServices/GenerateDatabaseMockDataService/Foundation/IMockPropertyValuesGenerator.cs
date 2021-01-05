using DatabaseMetadataReaderService.DTOs;
using RWS.MockGen.DTOs;

namespace RWS.MockGen
{
    public interface IMockPropertyValuesGenerator
    {
        MockDataPropertyValues GenerateMockedValuesByPropertyMetadata(SchemaPropertyMetadata propertyMetadata, MockDataGeneratorOptions options);
    }
}