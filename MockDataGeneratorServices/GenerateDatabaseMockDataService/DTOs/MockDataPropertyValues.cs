namespace GenerateMockDataService.DTOs
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class MockDataPropertyValues
    {
        public string Name { get; set; }

        public List<dynamic> Values { get; private set; } = new List<dynamic>();
    }
}
