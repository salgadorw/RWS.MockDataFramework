using DatabaseMetadataReader.DTOs;
using MockDataGenerator.DTOs;

namespace MockDataGenerator
{
    public interface IMockPropertyValuesGenerator
    {
        MockDataPropertyValues GenerateMockedValuesByPropertyMetadata(SchemaPropertyMetadata propertyMetadata, MockDataGeneratorOptions options);
    }
}