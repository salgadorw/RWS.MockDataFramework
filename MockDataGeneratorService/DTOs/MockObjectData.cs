using MockMetadataReader.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MockDataGenerator.DTOs
{
    public class MockObjectData
    {
        public SchemaObjectMetadata Schema { get; set; }
               
        public IEnumerable<MockDataPropertyValues> propertyValues { get; set; } = new List<MockDataPropertyValues>();
         
    }
}
