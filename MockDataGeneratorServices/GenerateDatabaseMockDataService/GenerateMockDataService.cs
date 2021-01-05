namespace GenerateMockDataService
{
    
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using global::GenerateMockDataService.Foundation;
    using DatabaseMetadataReaderService.Foundation;
    using DatabaseMetadataReaderService.SqlServerImplementation;
    using global::GenerateMockDataService.DTOs;

    public class GenerateMockDataService : IGenerateMockDataService
    {
        public GenerateMockDataService() { 
        
        }

        public async Task<string> GenerateSQLServerDatabaseMockDataByCOnnectionString(string connectionString, params MockDataGeneratorOptions[] options)
        {
            var DatabaseMetadata = await new SQLServerDatabaseSchemaReader(new SQLServerMetadataRepository(connectionString)).ReadAllAsync();

            var generateMockDataService = new GenerateSqlServerMockData();
            var result = await generateMockDataService.GenerateMockDataByMetadataSchema(DatabaseMetadata, new MockDataGeneratorOptions() { DataAmount = 10 }).ConfigureAwait(false);
           
            return result.ToString();

        }
    }
}
