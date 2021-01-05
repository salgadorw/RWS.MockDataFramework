namespace RWS.MockGen.DTOs
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class MockDataGeneratorOptions
    {
        public string ObjectName { get; set; }

        public int? DataAmount { get; set; }

        public List<MockDataPropertyValues> BaseValues { get; set; }

        public List<MockDataPropertyValues> DefaultValues { get; set; }

    }
}
