namespace IntegrationTests
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;
    using Dapper;
    using MockMetadataReader;
    using MockMetadataReader.Foundation;
    using MockMetadataReader.SqlServerImplementation;
    using MockDataGenerator.SqlServerImplementation;
    using MockDataGenerator.Foundation;
    using Xunit;


    public class SqlServerTests
    {
        private const string dockerContainerConnnectionString = "Data Source=localhost,1433;Connection Timeout=180;Initial Catalog=master;Persist Security Info=True;User ID=sa;Password=1@sqlServer";
        private const string dockerContainerDBConnnectionString = "Data Source=localhost,1433;Connection Timeout=180;Initial Catalog=MockedDB;Persist Security Info=True;User ID=sa;Password=1@sqlServer";

        private readonly IDatabaseSchemaRead databaseSchemaReadService;
        private readonly IMockDataGeneratorService mockDataGeneratorService;

        public SqlServerTests()
        {
            using (var conn = new SqlConnection(dockerContainerConnnectionString))
            {
                conn.Execute(SqlScripts.CreateTestDatabase);
              
            }
            IDatabaseMetadataRepository repository = new SQLServerMetadataRepository(dockerContainerDBConnnectionString);
            databaseSchemaReadService = new SQLServerDatabaseSchemaReader(repository);
            mockDataGeneratorService = new SqlServerMockDataGeneratorService();
        }

        [Fact]
        public async Task ReadALL_ReturnSchema()
        {
            var result = await databaseSchemaReadService.ReadAllAsync();
            Assert.NotNull(result);
            Assert.Equal(2, result.DatabaseObjects.Count());
            Assert.Single(result.DatabaseObjectRelations);
        }

        [Fact]
        public async Task GenerateSQLServerDatabaseMockDataByCOnnectionString_ReturnMockedData()
        {
            var result = await mockDataGeneratorService.GenerateMockDataByConnectionString(dockerContainerDBConnnectionString);
            Assert.NotNull(result);
           
        }
    }
}
