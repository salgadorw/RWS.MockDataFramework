using System;
using System.Collections.Generic;
using System.Text;

namespace GenerateMockDataService.DTOs
{
    public class MockObjectData
    {
        public string SchemaName { get; set; }
        public string ObjectName { get; set; }
               
        public IEnumerable<MockDataPropertyValues> propertyValues { get; set; } = new List<MockDataPropertyValues>();
         
    }
}
