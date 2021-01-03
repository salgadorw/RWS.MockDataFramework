namespace GenerateMockDataService
{
    using System.Collections.Generic;

    using DatabaseMetadataReaderService.DTOs;
    using global::GenerateMockDataService.DTOs;
    


    internal static class MockPropertiesValueGeneratorExtensions
    {
        public static MockDataPropertyValues GenerateMockedValue(this SchemaPropertyMetadata propertyMetadata, MockDataGeneratorOptions options) {

            var result = new MockDataPropertyValues();

            result.Name = propertyMetadata.Name;



            return result;
            

        
        }
    }
}
