using DatabaseMetadataReaderService.DTOs;
using GenerateMockDataService.DTOs;
using GenerateMockDataService.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateMockDataService
{
    public class GenerateSqlServerMockData : IMockDataGemerator
    {
        public Task<IEnumerable<MockObjectData>> GenerateMockDataByMetadataSchema(SchemaMetadata schema, params MockDataGeneratorOptions[] options)
        {
            return Task.FromResult( 
                schema.DatabaseObjects
                .Select(s => new MockObjectData()
                    {   SchemaName = schema.Name, 
                        ObjectName = s.Name, 
                        propertyValues = 
                        s.DatabaseObjectProperties
                        .Select
                        (sp => 
                            sp.GenerateSqlServerMockedFieldValues
                            (
                                options.Where(w=> w.ObjectName.Equals(s.Name)).FirstOrDefault()
                            )
                        ) 
                    }
                ));
        }
    }
}
