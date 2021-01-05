using DatabaseMetadataReader.DTOs;
using MockDataGenerator.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MockDataGenerator.Foundation
{
    public interface IMockDataGenerator
    {
        Task<IEnumerable<MockObjectData>> GenerateMockDataByMetadataSchema(SchemaMetadata schema, MockDataGeneratorOptions[] options);
    }
}
