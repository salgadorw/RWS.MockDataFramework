namespace MockDataGenerator.SqlServerImplementation
{
    
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using global::MockDataGenerator.Foundation;
    using MockMetadataReader.Foundation;
    using MockMetadataReader.SqlServerImplementation;
    using MockDataGenerator.DTOs;

    public class SqlServerMockDataGeneratorService : IMockDataGeneratorService
    {
        public SqlServerMockDataGeneratorService() { 
        
        }

        public async Task<string> GenerateMockDataByConnectionString(string connectionString, params MockDataGeneratorOptions[] options)
        {
            var DatabaseMetadata = await new SQLServerDatabaseSchemaReader(new SQLServerMetadataRepository(connectionString)).ReadAllAsync();

            var sqlServerMockDataGenerator = new SqlserverMockDataGenerator();
            var result = await sqlServerMockDataGenerator.GenerateMockDataByMetadataSchema(DatabaseMetadata, new MockDataGeneratorOptions() { DataAmount = 10 }).ConfigureAwait(false);
           
            return result.ToString();

        }
    }
}
