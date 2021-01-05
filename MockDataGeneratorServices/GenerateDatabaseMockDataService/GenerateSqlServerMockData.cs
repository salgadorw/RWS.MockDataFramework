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
        public async Task<IEnumerable<MockObjectData>> GenerateMockDataByMetadataSchema(SchemaMetadata schema, params MockDataGeneratorOptions[] options)
        {
            return await Task.Run(()=>
               
                    schema.DatabaseObjects.Select
                    (s =>
                        
                        {
                            var propertyGenerator = new MockPropertyValuesGenerator();
                            var opt = options.Where(w => (w.ObjectName ?? "").Equals(s.Name) || w.ObjectName == null).FirstOrDefault();
                            return new MockObjectData()
                                {
                                    SchemaName = schema.Name,
                                    ObjectName = s.Name,
                                    propertyValues =
                                    s.DatabaseObjectProperties
                                    .Select(
                                    sp =>
                                        {
                                            return propertyGenerator.GenerateSqlServerMockedFieldValues(sp, opt);
                                        }
                                    )
                                };
                        }
                    ).ToList()
                ).ConfigureAwait(false);
        }
    }
}
