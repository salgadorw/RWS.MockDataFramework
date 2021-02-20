using MockMetadataReader.DTOs;
using System.Collections.Generic;

namespace MockDataGenerator.DTOs
{
    public class MockObjectData
    {
        public SchemaObjectMetadata Schema { get; set; }
               
        public IEnumerable<MockDataPropertyValues> propertyValues { get; set; } = new List<MockDataPropertyValues>();
         
    }
}
