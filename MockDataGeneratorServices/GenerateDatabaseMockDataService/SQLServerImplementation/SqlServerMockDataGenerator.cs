using DatabaseMetadataReaderService.DTOs;
using RWS.MockGen.DTOs;
using RWS.MockGen.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWS.MockGen.SqlServerImplementation
{
    internal class SqlserverMockDataGenerator : IMockDataGenerator
    {
        public async Task<IEnumerable<MockObjectData>> GenerateMockDataByMetadataSchema(SchemaMetadata schema, params MockDataGeneratorOptions[] options)
        {
            return await Task.Run(()=>
               
                    schema.DatabaseObjects.Select
                    (s =>
                        
                        {
                            var propertyGenerator = new SqlServerMockPropertiesValueGenerator();
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
                                            return propertyGenerator.GenerateMockedValuesByPropertyMetadata(sp, opt);
                                        }
                                    )
                                };
                        }
                    ).ToList()
                ).ConfigureAwait(false);
        }
    }
}
