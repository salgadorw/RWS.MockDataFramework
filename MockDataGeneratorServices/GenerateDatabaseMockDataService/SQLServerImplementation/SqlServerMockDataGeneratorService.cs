namespace RWS.MockGen.SqlServerImplementation
{
    
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using global::RWS.MockGen.Foundation;
    using DatabaseMetadataReaderService.Foundation;
    using DatabaseMetadataReaderService.SqlServerImplementation;
    using RWS.MockGen.DTOs;

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
