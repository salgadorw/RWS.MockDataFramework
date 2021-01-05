using DatabaseMetadataReader.DTOs;
using RWS.MockGen.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RWS.MockGen.Foundation
{
    public interface IMockDataGenerator
    {
        Task<IEnumerable<MockObjectData>> GenerateMockDataByMetadataSchema(SchemaMetadata schema, MockDataGeneratorOptions[] options);
    }
}
