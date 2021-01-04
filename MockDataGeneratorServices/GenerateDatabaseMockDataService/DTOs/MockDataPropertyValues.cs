namespace GenerateMockDataService.DTOs
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class MockDataPropertyValues
    {
        public string ObjectName { get; set; }
        
        public string PropertyName { get; set; }

        public Type PropertyType { get; set; }

        public List<object> Values { get; private set; } = new List<object>();
    }
}
