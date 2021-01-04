using DatabaseMetadataReaderService.DTOs;
using GenerateMockDataService.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenerateMockDataService.Foundation
{
    public interface IMockDataGemerator
    {
        Task<IEnumerable<MockObjectData>> GenerateMockDataByMetadataSchema(SchemaMetadata schema, MockDataGeneratorOptions[] options);
    }
}
