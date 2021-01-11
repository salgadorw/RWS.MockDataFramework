using System.Collections.Generic;
using System.Threading.Tasks;
using MockDataGenerator.Foundation;
using MockMetadataReader.SqlServerImplementation;
using MockDataGenerator.DTOs;

namespace MockDataGenerator.SqlServerImplementation
{
    public class SqlServerMockDataGeneratorService : IMockDataGeneratorService
    {
        public SqlServerMockDataGeneratorService() { 
        
        }

        public async Task<IEnumerable<MockObjectData>> GenerateMockDataByConnectionString(string connectionString, params MockDataGeneratorOptions[] options)
        {
            var DatabaseMetadata = await new SQLServerDatabaseSchemaReader(new SQLServerMetadataRepository(connectionString)).ReadAllAsync();

            var sqlServerMockDataGenerator = new SqlserverMockDataGenerator();
            var result = await sqlServerMockDataGenerator.GenerateMockDataByMetadataSchema(DatabaseMetadata, new MockDataGeneratorOptions() { DataAmount = 10 }).ConfigureAwait(false);
           
            return result;

        }
    }
}
