namespace MockDataGenerator.DTOs
{
    using System.Collections.Generic;


    public class MockDataGeneratorOptions
    {
        public string ObjectName { get; set; }

        public int? DataAmount { get; set; }

        public List<MockDataPropertyValues> BaseValues { get; set; }

        public List<MockDataPropertyValues> DefaultValues { get; set; }

    }
}
