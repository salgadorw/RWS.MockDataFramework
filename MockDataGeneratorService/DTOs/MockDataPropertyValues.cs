namespace MockDataGenerator.DTOs
{
    using System;
    using System.Collections.Generic;


    public class MockDataPropertyValues
    {
        public string PropertyName { get; set; }

        public Type PropertyType { get; set; }

        public List<object> Values { get; set; } = new List<object>();
    }
}
